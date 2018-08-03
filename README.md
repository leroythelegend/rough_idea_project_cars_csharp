# Rough Idea Project Cars CSharp

## Description

This is work in progress, these are my first attempts at CSharp so I have a big learning curve.
I'm just going to add/change files as I go, so to build anything you will have to create your own local project.

No Guarantee this is going to work or be correct I'm just going to post code as I do minimal testing to get something to work i.e. small iterations and being concrete early.

Also have done a set of C++ Classes https://github.com/leroythelegend/rough_idea_project_cars

## Contents

* [Reader](#C-Reader)
* [Decoder](#C-Decoder)

## <a name="C-Reader"></a>Reader

Set of IReader Classes for reading UDP packets.

NOTE: I still need to think on the exception handling.

### IReader

Interface for Reader

```
    public interface IReader
    {
        Byte[] Read();
    }
```

### UDPNonBlockingReader

```
  // Create a UDPNonBlockingReader object with the port number you want to bind too
  // This works a bit better, but you have to check you don't have a 0 length Byte array
  // Project Cars UDP uses port number 5606
  UDPNonBlockingReader reader = new UDPNonBlockingReader(5606);
  
  // Call Read, this will not block but will return a 0 length Byte if 
  // there was nothing to read.
  // So need to check the length of the returned Byte array
  Byte[] bytes = reader.Read();
  if (bytes.Length > 0) { ...
```

### UDPBlockingReader

```
  // Create a UDPBlockingReader object with the port number you want to bind too
  // Project Cars UDP uses port number 5606
  UDPBlockingReader reader = new UDPBlockingReader(5606);
  
  // Call Read, this will block i.e. will not return until there is something to return.
  Byte[] bytes = reader.Read();
```

## <a name="C-Decoder"></a>Decoder

Set of IDecoder Classes for decoding pcar packets.

### IDecoder

Interface for Decoder

```
    public interface IDecoder
    {
        void Decode(ref Byte[] bytes, ref int index);
    }
```

### UIntDecoder

Decodes 4 bytes from a byte array into a UInt from the index of the array.

```
  UIntDecoder decode = new UIntDecoder();
  decode.Decode(ref bytes, ref index);
  uint data = decode.UInt();
```
### OneByteDecoder

Decodes 1 byte from a byte array into a UInt or a Byte from the index of the array.

```
  OneByteDecoder decode = new OneByteDecoder();
  decode.Decode(ref bytes, ref index);
  uint data = decode.UInt();
  Byte byte = decode.OneByte();
```

### CompositeDecoder

Base of the pcar packet types.

### PacketBaseDecoder

This is the first part of the specific PCars Packets, here I'm decoding the Packet base where all the PCar Packets on the wire have a PacketBase.

```
            // Create a packetBase object
            PacketBaseDecoder packetBase = new PacketBaseDecoder();
            // Use our reader to read the UDP telemetry packets
            IReader reader = new UDPNonBlockingReader(5606);
            
            while (true) {
                Byte[] bytes = reader.Read();
                if (bytes.Length > 0)
                {
                    int index = 0;  // Set the index to the beginning of the returned packet
                    packetBase.Decode(ref bytes, ref index); // Decode the returned packet into a PCars PacketBase

                    //0 counter reflecting all the packets that have been sent during the game run (SMS_UDP_Definitions.hpp)
                    Console.WriteLine("Packet Number          " + packetBase.packetNumber.UInt());
                    
                    //4 counter of the packet groups belonging to the given category (SMS_UDP_Definitions.hpp)
                    Console.WriteLine("Category Packet Number " + packetBase.categoryPacketNumber.UInt());
                    
                    //8 If the data from this class had to be sent in several packets, the index number (SMS_UDP_Definitions.hpp)
                    Console.WriteLine("Partial Packet Index   " + packetBase.partialPacketIndex.UInt());
                    
                    //9 If the data from this class had to be sent in several packets, the total number (SMS_UDP_Definitions.hpp)
                    Console.WriteLine("Partial Packet Number  " + packetBase.partialPacketNumber.UInt());
                    
                    //10 what is the type of this packet (see EUDPStreamerPacketHanlderType for details) (SMS_UDP_Definitions.hpp)
                    Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());
                    
                    //11 what is the version of protocol for this handler, to be bumped with data structure change
                    Console.WriteLine("Packet Version         " + packetBase.packetVersion.UInt());                    
                }
            }
```
### TimingDataDecoder
```
            // Create a packetBase object
            PacketBaseDecoder packetBase = new PacketBaseDecoder();
            // Use our reader to read the UDP telemetry packets
            IReader reader = new UDPNonBlockingReader(5606);
            
            while (true) {
                Byte[] bytes = reader.Read();
                if (bytes.Length > 0)
                {
                    int index = 0;
                    packetBase.Decode(ref bytes, ref index);

                    Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());
                    // ok so from the packet base we know that 3 is the timingData
                    if (packetBase.packetType.UInt() == 3) 
                    {
                        // Create our timingdata object
                        TimingsDataDecoder timingData = new TimingsDataDecoder();
                        // important to reset the index back to 0 for the begining of the packet because 
                        // we decode the packetbase again to include it in the timingdata object
                        index = 0;                        
                        timingData.Decode(ref bytes, ref index);
                        // take a look at TimingDataDecoder and ParticipantInfoDecoder to see the data you can extract
                        Console.WriteLine("Current Sector Time" + 
                                       timingData.participants.data[timingData.localParticipantIndex.UShort()].currentSectorTime.Float());
                        Console.WriteLine("Current Time " +
                                       timingData.participants.data[timingData.localParticipantIndex.UShort()].currentTime.Float());
                    }
                }                  
            }
```
