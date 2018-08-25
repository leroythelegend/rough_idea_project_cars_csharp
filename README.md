# Rough Idea Project Cars CSharp

## Description

This is work in progress, these are my first attempts at CSharp so I have a big learning curve.
I'm just going to add/change files as I go, so to build anything you will have to create your own local project.

No Guarantee this is going to work or be correct I'm just going to post code as I do minimal testing to get something to work i.e. small iterations and being concrete early.

Also have done a set of C++ Classes https://github.com/leroythelegend/rough_idea_project_cars

## Getting Started

## Capturing UDP packets

If you are interested in getting the raw packets and decoding them yourself just one of use these classes

# UDPBlockingReader 

Will wait/block until there is some data to read. I don't recommend using this, however if you really want something super simple and just want to decode some specific data go for it.

```
        UDPBlockingReader reader(5606);
        var data = reader.Read()
        // Process data       
```

# UDPNonBlockingReader

Will not wait and return an empty Byte Array if there is no data ready to read. If there is data to read returns the whole packet.

```
        UDPBlockingReader reader(5606);
        var bytes = reader.Read();
        while (true)
        {
           if (bytes.Length > 0)
           {
              // Process data
           }
        }
```

## Decoding Packets

This is the Project Cars Version 2 header file https://www.projectcarsgame.com/wp-content/uploads/2018/05/SMS_UDP_Definitions_v2_Patch5.zip.

You use the Decoder classes to decode the packet from the UDP read.

Have a look at UDPProcess.cs and Test.cs for an example of using the Decoder classes

```
// list of packets from the pcars header file
enum EUDPStreamerPacketHandlerType
{
	eCarPhysics = 0,         // TelemetryDataDecoder
	eRaceDefinition = 1,     // RaceDataDecoder
	eParticipants = 2,       // ParticipantsDataDecoder
	eTimings = 3,            // TimingsDataDecoder
	eGameState = 4,          // GameStateDataDecoder
	eWeatherState = 5, // not sent at the moment, information can be found in the game state packet
	eVehicleNames = 6, //not sent at the moment
	eTimeStats = 7,          // TimeStatsDataDecoder
	eParticipantVehicleNames = 8  // ParticipantVehicleNamesDataDecoder && VehicleClassNamesDataDecoder
};
```

Brief example

```
   var bytes = reader.Read(); // Read Packet
   if (bytes.Length > 0)      // Did you get a packet
   {
      int index = 0;          // set search index to 0
      var packetBase = new PacketBaseDecoder(); // This is the base class that all packets have

      packetBase.Decode(ref bytes, ref index);  // decode raw bytes into a packet object

      if (packetBase.packetType.UInt() == 0 && bytes.Length == 559) // Do you have packet type TelemetryDataDecoder
      {
          var telem = new TelemetryDataDecoder(); // new telemetry object
          index = 0;                              // reset index back to 0;

          telem.Decode(ref bytes, ref index);     // now decode the bytes into a telem object
          
          Console.WriteLine(telem.EngineSpeed()); // Show the current engine speed
      }
```

## Process Classes

# PacketQueue, UDPProcess and ConsoleProcess.

You don't have to use these classes this is just the way I have done it.  I'm using the "Filter and Pipe" architecture IProcess are the filters and the pipe is PacketQueue.

UDPProcess pushes to the PacketQueue and the ConsoleProcess pops from the PacketQueue this way I can run to seperate threads and use the pipe as a buffer if one process processes quicker that the other.

If you have an idea of what you want to do create your own IProcess class and replace the ConsoleProcess with your own.

Look at Program.cs for an example of using these classes.

```
            var packetQueue = new PacketQueue();
            var udpProcess = new UDPProcess(ref packetQueue);
            var consoleProcess = new ConsoleProcess(ref packetQueue);  // Create your own IProcess and replace ConsoleProcess here

            var udpThread = new Thread(new ThreadStart(udpProcess.Process));
            var consoleThread = new Thread(new ThreadStart(consoleProcess.Process));

            udpThread.Start();
            consoleThread.Start();
```

## State

This something you dont have to follow just the way I did it, I use the GOF State Pattern here so that you can record and display the telemetry based on what GameState you are in.

In the GamePlayingState I call record to capture packets and then in the GameMenuState I call display to process what was captured and then display it.

```
        ICaptureState state;   // This is interface for the different states

        public Capture(IRecord record, IDisplay display) // Capture is the entry point into the different game states
        {                                                // IRecord is what you want to record and IDisplay is how you want to display it
            state = new GameFrontEndState(record, display); // First State GameFrontEndState.
        }
```
