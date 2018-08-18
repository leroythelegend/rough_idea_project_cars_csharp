using System;

namespace pcars
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PacketBaseDecoder packetBase = new PacketBaseDecoder();
            IReader reader = new UDPNonBlockingReader(5606);
            while (true) {
                Byte[] bytes = reader.Read();
                if (bytes.Length > 0)
                {
                    int index = 0;
                    packetBase.Decode(ref bytes, ref index);

                    //Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());

                    if (packetBase.packetType.UInt() == 8 && packetBase.partialPacketIndex.UInt() == 2)
                    {
                        Console.WriteLine("Packet Type              " + packetBase.packetType.UInt());
                        Console.WriteLine("Packet number            " + packetBase.partialPacketNumber.UInt());
                        Console.WriteLine("Packet index             " + packetBase.partialPacketIndex.UInt());


                        VehicleClassNamesDataDecoder className = new VehicleClassNamesDataDecoder();
                        index = 0;
                        className.Decode(ref bytes, ref index);

                        for (int i = 0; i < 60; ++i)
                        {
                            Console.WriteLine("class index " + i + "                 " +
                                              className.classInfo.ClassInfoArray(i).classIndex.UInt());

                            Console.WriteLine("name " + i + "                        " +
                                              className.classInfo.ClassInfoArray(i).name.String(0));
                        }
                    }

                    if (packetBase.packetType.UInt() == 8 && packetBase.partialPacketIndex.UInt() == 1)
                    // disabled
                    // if (packetBase.packetType.UInt() == 8000 && packetBase.partialPacketIndex.UInt() == 1)
                    {
                        Console.WriteLine("Packet Type              " + packetBase.packetType.UInt());
                        Console.WriteLine("Packet number            " + packetBase.partialPacketNumber.UInt());
                        Console.WriteLine("Packet index             " + packetBase.partialPacketIndex.UInt());


                        ParticipantVehicleNamesDataDecoder vehicleName = new ParticipantVehicleNamesDataDecoder();
                        index = 0;
                        vehicleName.Decode(ref bytes, ref index);

                        for (int i = 0; i < 16; ++i)
                        {
                            Console.WriteLine("index " + i + "                       " +
                                              vehicleName.vehicles.VehicleInfoArray(i).index.UInt());

                            Console.WriteLine("class " + i + "                       " +
                                              vehicleName.vehicles.VehicleInfoArray(i).vehicleClass.UInt());

                            Console.WriteLine("name " + i + "                        " +
                                              vehicleName.vehicles.VehicleInfoArray(i).name.String(0));
                        }
                    }

                    //if (packetBase.packetType.UInt() == 7 && bytes.Length == 1040)
                        // disable
                    if (packetBase.packetType.UInt() == 7000 && bytes.Length == 1040)
                    {
                        Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());

                        TimeStatsDataDecoder timestats = new TimeStatsDataDecoder();
                        index = 0;
                        timestats.Decode(ref bytes, ref index);

                        Console.WriteLine("participants Changed Timestamp                   " +
                                          timestats.participantsChangedTimestamp.UInt());
                        

                        for (int i = 0; i < 32; ++i)
                        {
                            Console.WriteLine("fastest lap time " + i + "                       " +
                                              timestats.stats.ParticipantsStatsArray(i).fastestLapTime.TimeStamp());

                            Console.WriteLine("fastest sector 1 time " + i + "                  " +
                                              timestats.stats.ParticipantsStatsArray(i).fastestSector1Time.TimeStamp());


                            Console.WriteLine("fastest sector 2 time " + i + "                  " +
                                              timestats.stats.ParticipantsStatsArray(i).fastestSector2Time.TimeStamp());


                            Console.WriteLine("fastest sector 3 time " + i + "                  " +
                                              timestats.stats.ParticipantsStatsArray(i).fastestSector3Time.TimeStamp());


                            Console.WriteLine("last lap time " + i + "                          " +
                                              timestats.stats.ParticipantsStatsArray(i).lastLapTime.TimeStamp());


                            Console.WriteLine("last sector time " + i + "                       " +
                                              timestats.stats.ParticipantsStatsArray(i).lastSectorTime.TimeStamp());


                            Console.WriteLine("participant Online Rep " + i + "                 " +
                                              timestats.stats.ParticipantsStatsArray(i).participantOnlineRep.UInt());


                            Console.WriteLine("MP Participant Index " + i + "                   " +
                                              timestats.stats.ParticipantsStatsArray(i).MPParticipantIndex.UShort());
                        }
                    }

                    // if (packetBase.packetType.UInt() == 4 && bytes.Length == 24)
                    // disable 
                    if (packetBase.packetType.UInt() == 4000 && bytes.Length == 24)
                    {
                        Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());

                        GameStateDataDecoder gamestate = new GameStateDataDecoder();
                        index = 0;
                        gamestate.Decode(ref bytes, ref index);

                        Console.WriteLine("build version number                   " +
                                          gamestate.buildVersionNumber.UShort());

                        Console.WriteLine("game state                             " +
                                          gamestate.gameState.GameState());
                        
                        Console.WriteLine("session state                          " +
                                          gamestate.gameState.SessionState());

                        Console.WriteLine("ambient Temperature                    " +
                                          gamestate.ambientTemperature.Int());

                        Console.WriteLine("track Temperature                      " +
                                          gamestate.trackTemperature.Int());

                        Console.WriteLine("rain Density                           " +
                                          gamestate.rainDensity.UInt());

                        Console.WriteLine("snow Density                           " +
                                          gamestate.snowDensity.UInt());

                        Console.WriteLine("wind Speed                             " +
                                          gamestate.windSpeed.Int());

                        Console.WriteLine("wind DirectionX                   " +
                                          gamestate.windDirectionX.Int());

                        Console.WriteLine("wind DirectionY                   " +
                                          gamestate.windDirectionY.Int());

                    }

                    // if (packetBase.packetType.UInt() == 2 && bytes.Length == 1136)
                        //disabled
                    if (packetBase.packetType.UInt() == 2000 && bytes.Length == 1136)
                    {
                        Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());

                        ParticipantsDataDecoder participants = new ParticipantsDataDecoder();
                        index = 0;
                        participants.Decode(ref bytes, ref index);

                        Console.WriteLine("participants Changed Timestamp                   " +
                                          participants.participantsChangedTimestamp.UInt());

                        // I get a bunch of different names here not sure how this works
                        for (int i = 0; i < 16; ++i)
                        {
                            Console.WriteLine("name " + i + "                " +
                                              participants.name.String(i));
                        }

                        for (int i = 0; i < 16; ++i)
                        {
                            Console.WriteLine("nationality " + i + "         " +
                                              participants.nationality.UInt(i));
                        }

                        for (int i = 0; i < 16; ++i)
                        {
                            Console.WriteLine("index " + i + "               " +
                                              participants.index.UShort(i));
                        }

                    }

                    //if (packetBase.packetType.UInt() == 1 && bytes.Length == 308)
                    //disable
                    if (packetBase.packetType.UInt() == 10000 && bytes.Length == 308)
                    {
                        Console.WriteLine("Packet Type            " + packetBase.packetType.UInt());

                        RaceDataDecoder race = new RaceDataDecoder();
                        index = 0;
                        race.Decode(ref bytes, ref index);

                        Console.WriteLine("world Fastest Lap Time                   " +
                                          race.worldFastestLapTime.TimeStamp());

                        Console.WriteLine("personel Fastest Lap Time                " +
                                          race.personalFastestLapTime.TimeStamp());

                        Console.WriteLine("personal Fastest Sector1 Time            " +
                                          race.personalFastestSector1Time.TimeStamp());

                        Console.WriteLine("personal Fastest Sector2 Time            " +
                                          race.personalFastestSector2Time.TimeStamp());

                        Console.WriteLine("personal Fastest Sector3 Time            " +
                                          race.personalFastestSector3Time.TimeStamp());

                        Console.WriteLine("world Fastest Sector1 Time               " +
                                          race.worldFastestSector1Time.TimeStamp());

                        Console.WriteLine("world Fastest Sector2 Time               " +
                                          race.worldFastestSector2Time.TimeStamp());

                        Console.WriteLine("world Fastest Sector3 Time               " +
                                          race.worldFastestSector3Time.TimeStamp());

                        Console.WriteLine("track length                             " +
                                          race.trackLength.Float());

                        Console.WriteLine("track location                           " +
                                          race.trackLocation.String(0));

                        Console.WriteLine("track variation                          " +
                                          race.trackVariation.String(0));

                        Console.WriteLine("translated Track Location                " +
                                          race.translatedTrackLocation.String(0));
                        
                        Console.WriteLine("translated Track Variation               " +
                                          race.translatedTrackVariation.String(0));
                        
                        Console.WriteLine("is timed event                           " +
                                          race.lapsTimeInEvent.IsTimedEvent());
                        
                        Console.WriteLine("laps                                     " +
                                          race.lapsTimeInEvent.Laps());

                        Console.WriteLine("Time in Event                            " +
                                          race.lapsTimeInEvent.TimeInEvent());
                        
                        Console.WriteLine("enforced Pit Stop Lap                    " +
                                          race.enforcedPitStopLap.Int());

                    }
                    //if (packetBase.packetType.UInt() == 0 && bytes.Length == 559)
                    // disabled
                    if (packetBase.packetType.UInt() == 5555 && bytes.Length == 1063)
                    {
                        TelemetryDataDecoder telem = new TelemetryDataDecoder();
                        index = 0;
                        telem.Decode(ref bytes, ref index);

                        Console.WriteLine("participant index                " + 
                                          telem.viewedParticipantIndex.Int());

                        Console.WriteLine("unfiltered throttle              " +
                                          telem.unfilteredThrottle.UInt());

                        Console.WriteLine("unfiltered brake                 " +
                                          telem.unfilteredBrake.UInt());

                        Console.WriteLine("unfiltered steering              " +
                                          telem.unfilteredSteering.Int());

                        Console.WriteLine("unfiltered clutch                " +
                                          telem.unfilteredClutch.UInt());

                        Console.WriteLine("car flags                        " +
                                          telem.carFlags.CarFlags());

                        Console.WriteLine("oil temp celsius                 " +
                                          telem.oilTempCelsius.Short());

                        Console.WriteLine("oil pressure kpa                 " +
                                          telem.oilPressureKPa.UShort());

                        Console.WriteLine("water Temp Celsius               " +
                                          telem.waterTempCelsius.Short());

                        Console.WriteLine("water Pressure Kpa               " +
                                          telem.waterPressureKpa.UShort());

                        Console.WriteLine("fuel pressure kpa                " +
                                          telem.fuelPressureKpa.UShort());

                        Console.WriteLine("fuel capacity                    " +
                                          telem.fuelCapacity.UInt());

                        Console.WriteLine("brake                            " +
                                          telem.brake.UInt());

                        Console.WriteLine("throttle                         " +
                                          telem.throttle.UInt());

                        Console.WriteLine("clutch                           " +
                                          telem.clutch.UInt());

                        // between 1 full to 0 empty
                        Console.WriteLine("fuel level                       " +
                                          telem.fuelLevel.Float());

                        Console.WriteLine("speed                            " +
                                          telem.speed.Float());

                        Console.WriteLine("rpm                              " +
                                          telem.rpm.UShort());

                        Console.WriteLine("max rpm                          " +
                                          telem.maxRpm.UShort());

                        Console.WriteLine("steering                         " +
                                          telem.steering.Int());

                        Console.WriteLine("gear                             " +
                                          telem.gearNumGears.Gear());

                        Console.WriteLine("num gear                         " +
                                          telem.gearNumGears.NumGears());

                        Console.WriteLine("boost amount                     " +
                                          telem.boostAmount.UInt());

                        Console.WriteLine("odometer KM                      " +
                                          telem.odometerKM.Float());

                        Console.WriteLine("orientation 0                    " +
                                          telem.orientation.Float(0));

                        Console.WriteLine("orientation 1                    " +
                                          telem.orientation.Float(1));

                        Console.WriteLine("orientation 2                    " +
                                          telem.orientation.Float(2));

                        Console.WriteLine("local velocity 0                 " +
                                          telem.localVelocity.Float(0));

                        Console.WriteLine("local velocity 1                 " +
                                           telem.localVelocity.Float(1));

                        Console.WriteLine("local velocity 2                 " +
                                           telem.localVelocity.Float(2));

                        Console.WriteLine("world velocity 0                 " +
                                          telem.worldVelocity.Float(0));

                        Console.WriteLine("world velocity 1                 " +
                                          telem.worldVelocity.Float(1));

                        Console.WriteLine("local velocity 2                 " +
                                          telem.worldVelocity.Float(2));

                        Console.WriteLine("angular velocity 0               " +
                                          telem.angularVelocity.Float(0));

                        Console.WriteLine("angular velocity 1               " +
                                          telem.angularVelocity.Float(1));

                        Console.WriteLine("angular velocity 2               " +
                                          telem.angularVelocity.Float(2));

                        Console.WriteLine("local acceleration 0             " +
                                          telem.localAcceleration.Float(0));

                        Console.WriteLine("local acceleration 1             " +
                                          telem.localAcceleration.Float(1));

                        Console.WriteLine("local acceleration 2             " +
                                          telem.localAcceleration.Float(2));

                        Console.WriteLine("world acceleration 0             " +
                                          telem.worldAcceleration.Float(0));

                        Console.WriteLine("world acceleration 1             " +
                                          telem.worldAcceleration.Float(1));

                        Console.WriteLine("world acceleration 2             " +
                                          telem.worldAcceleration.Float(2)); 
                        
                        Console.WriteLine("extents centre 0                 " +
                                          telem.extentsCentre.Float(0));

                        Console.WriteLine("extents centre 1                 " +
                                           telem.extentsCentre.Float(1));

                        Console.WriteLine("extents centre 2                 " +
                                           telem.extentsCentre.Float(2));

                        Console.WriteLine("tyre flags 0                     " +
                                          telem.tyreFlags.TyreFlag(0));

                        Console.WriteLine("tyre flags 1                     " +
                                          telem.tyreFlags.TyreFlag(1));

                        Console.WriteLine("tyre flags 2                     " +
                                          telem.tyreFlags.TyreFlag(2));
                        
                        Console.WriteLine("tyre flags 3                     " +
                                          telem.tyreFlags.TyreFlag(3));
                        
                        Console.WriteLine("terrain 0                        " +
                                          telem.terrain.Terrain(0));

                        Console.WriteLine("terrain 1                        " +
                                          telem.terrain.Terrain(1));

                        Console.WriteLine("terrain 2                        " +
                                          telem.terrain.Terrain(2));

                        Console.WriteLine("terrain 3                        " +
                                          telem.terrain.Terrain(3));
                        
                        Console.WriteLine("tyre y 0                         " +
                                          telem.tyreY.Float(0));
                        
                        Console.WriteLine("tyre y 1                         " +
                                          telem.tyreY.Float(1));
                        
                        Console.WriteLine("tyre y 2                         " +
                                          telem.tyreY.Float(2));

                        Console.WriteLine("tyre y 3                         " +
                                          telem.tyreY.Float(3));

                        Console.WriteLine("tyre rps 0                       " +
                                          telem.tyreRPS.Float(0));

                        Console.WriteLine("tyre rps 1                       " +
                                          telem.tyreRPS.Float(1));

                        Console.WriteLine("tyre rps 2                       " +
                                          telem.tyreRPS.Float(2));

                        Console.WriteLine("tyre rps 3                       " +
                                          telem.tyreRPS.Float(3));

                        Console.WriteLine("tyre temp 0                      " +
                                          telem.tyreTemp.UInt(0));

                        Console.WriteLine("tyre temp 1                      " +
                                          telem.tyreTemp.UInt(1));

                        Console.WriteLine("tyre temp 2                      " +
                                          telem.tyreTemp.UInt(2));

                        Console.WriteLine("tyre temp 3                      " +
                                          telem.tyreTemp.UInt(3));

                        Console.WriteLine("tyre height above ground 0       " +
                                          telem.tyreHeightAboveGround.Float(0));

                        Console.WriteLine("tyre height above ground 1       " +
                                          telem.tyreHeightAboveGround.Float(1));

                        Console.WriteLine("tyre height above ground 2       " +
                                          telem.tyreHeightAboveGround.Float(2));

                        Console.WriteLine("tyre height above ground 3       " +
                                          telem.tyreHeightAboveGround.Float(3));

                        Console.WriteLine("tyre wear 0                      " +
                                          telem.tyreWear.UInt(0));

                        Console.WriteLine("tyre wear 1                      " +
                                          telem.tyreWear.UInt(1));

                        Console.WriteLine("tyre wear 2                      " +
                                          telem.tyreWear.UInt(2));

                        Console.WriteLine("tyre wear 3                      " +
                                          telem.tyreWear.UInt(3));

                        Console.WriteLine("brake damage 0                   " +
                                          telem.brakeDamage.UInt(0));
                        
                        Console.WriteLine("brake damage 1                   " +
                                          telem.brakeDamage.UInt(1));

                        Console.WriteLine("brake damage 2                   " +
                                          telem.brakeDamage.UInt(2));

                        Console.WriteLine("brake damage 3                   " +
                                          telem.brakeDamage.UInt(3));

                        Console.WriteLine("suspension damage 0              " +
                                          telem.suspensionDamage.UInt(0));

                        Console.WriteLine("suspension damage 1              " +
                                          telem.suspensionDamage.UInt(1));

                        Console.WriteLine("suspension damage 2              " +
                                          telem.suspensionDamage.UInt(2));

                        Console.WriteLine("suspension damage 3              " +
                                          telem.suspensionDamage.UInt(3));

                        Console.WriteLine("brake temp celsius 0             " +
                                          telem.brakeTempCelsius.Short(0));

                        Console.WriteLine("brake temp celsius 1             " +
                                          telem.brakeTempCelsius.Short(1));

                        Console.WriteLine("brake temp celsius 2             " +
                                          telem.brakeTempCelsius.Short(2));

                        Console.WriteLine("brake temp celsius 3             " +
                                          telem.brakeTempCelsius.Short(3));

                        Console.WriteLine("tyre tread temp 0                " +
                                          telem.tyreTreadTemp.UShort(0));

                        Console.WriteLine("tyre tread temp 1                " +
                                          telem.tyreTreadTemp.UShort(1));

                        Console.WriteLine("tyre tread temp 2                " +
                                          telem.tyreTreadTemp.UShort(2));

                        Console.WriteLine("tyre tread temp 3                " +
                                          telem.tyreTreadTemp.UShort(3));
                        
                        Console.WriteLine("tyre layer temp 0                " +
                                          telem.tyreLayerTemp.UShort(0)); 

                        Console.WriteLine("tyre layer temp 1                " +
                                          telem.tyreLayerTemp.UShort(1)); 

                        Console.WriteLine("tyre layer temp 2                " +
                                          telem.tyreLayerTemp.UShort(2)); 
                        
                        Console.WriteLine("tyre layer temp 3                " +
                                          telem.tyreLayerTemp.UShort(3)); 

                        Console.WriteLine("tyre carcass temp 0              " +
                                          telem.tyreCarcassTemp.UShort(0)); 
                        
                        Console.WriteLine("tyre carcass temp 1              " +
                                          telem.tyreCarcassTemp.UShort(1)); 

                        Console.WriteLine("tyre carcass temp 2              " +
                                          telem.tyreCarcassTemp.UShort(2)); 

                        Console.WriteLine("tyre carcass temp 3              " +
                                          telem.tyreCarcassTemp.UShort(3)); 

                        Console.WriteLine("tyre rim temp 0                  " +
                                          telem.tyreRimTemp.UShort(0)); 
                        
                        Console.WriteLine("tyre rim temp 1                  " +
                                          telem.tyreRimTemp.UShort(1)); 

                        Console.WriteLine("tyre rim temp 2                  " +
                                          telem.tyreRimTemp.UShort(2)); 

                        Console.WriteLine("tyre rim temp 3                  " +
                                          telem.tyreRimTemp.UShort(3)); 

                        Console.WriteLine("tyre internal air temp 0         " +
                                          telem.tyreInternalAirTemp.UShort(0));
                        
                        Console.WriteLine("tyre internal air temp 1         " +
                                          telem.tyreInternalAirTemp.UShort(1));

                        Console.WriteLine("tyre internal air temp 2         " +
                                          telem.tyreInternalAirTemp.UShort(2));

                        Console.WriteLine("tyre internal air temp 3         " +
                                          telem.tyreInternalAirTemp.UShort(3));

                        Console.WriteLine("tyre temp left 0                 " +
                                          telem.tyreTempLeft.UShort(0));

                        Console.WriteLine("tyre temp left 1                 " +
                                          telem.tyreTempLeft.UShort(1));
                        
                        Console.WriteLine("tyre temp left 2                 " +
                                          telem.tyreTempLeft.UShort(2));

                        Console.WriteLine("tyre temp left 3                 " +
                                          telem.tyreTempLeft.UShort(3));

                        Console.WriteLine("tyre temp centre 0               " +
                                          telem.tyreTempCenter.UShort(0));

                        Console.WriteLine("tyre temp centre 1               " +
                                          telem.tyreTempCenter.UShort(1));

                        Console.WriteLine("tyre temp centre 2               " +
                                          telem.tyreTempCenter.UShort(2));

                        Console.WriteLine("tyre temp centre 3               " +
                                          telem.tyreTempCenter.UShort(3));

                        Console.WriteLine("tyre temp right 0                " +
                                          telem.tyreTempRight.UShort(0));

                        Console.WriteLine("tyre temp right 1                " +
                                          telem.tyreTempRight.UShort(1));

                        Console.WriteLine("tyre temp right 2                " +
                                          telem.tyreTempLeft.UShort(2));

                        Console.WriteLine("tyre temp right 3                " +
                                          telem.tyreTempRight.UShort(3));

                        Console.WriteLine("wheel local position y 0         " +
                                          telem.wheelLocalPositionY.Float(0));

                        Console.WriteLine("wheel local position y 1         " +
                                          telem.wheelLocalPositionY.Float(1));

                        Console.WriteLine("wheel local position y 2         " +
                                          telem.wheelLocalPositionY.Float(2));

                        Console.WriteLine("wheel local position y 3         " +
                                          telem.wheelLocalPositionY.Float(3));

                        Console.WriteLine("ride height 0                    " +
                                          telem.rideHeight.Float(0));

                        Console.WriteLine("ride height 1                    " +
                                          telem.rideHeight.Float(1));
                        
                        Console.WriteLine("ride height 2                    " +
                                          telem.rideHeight.Float(2));

                        Console.WriteLine("ride height 3                    " +
                                          telem.rideHeight.Float(3));

                        Console.WriteLine("suspension travel 0              " +
                                          telem.suspensionTravel.Float(0));

                        Console.WriteLine("suspension travel 1              " +
                                          telem.suspensionTravel.Float(1));

                        Console.WriteLine("suspension travel 2              " +
                                          telem.suspensionTravel.Float(2));

                        Console.WriteLine("suspension travel 3              " +
                                          telem.suspensionTravel.Float(3));

                        Console.WriteLine("suspension velocity 0            " +
                                          telem.suspensionVelocity.Float(0));

                        Console.WriteLine("suspension velocity 1            " +
                                          telem.suspensionVelocity.Float(1));

                        Console.WriteLine("suspension velocity 2            " +
                                          telem.suspensionVelocity.Float(2));

                        Console.WriteLine("suspension velocity 3            " +
                                          telem.suspensionVelocity.Float(3));

                        Console.WriteLine("suspension ride height 0         " +
                                          telem.suspensionRideHeight.UShort(0));

                        Console.WriteLine("suspension ride height 1         " +
                                          telem.suspensionRideHeight.UShort(1));

                        Console.WriteLine("suspension ride height 2         " +
                                          telem.suspensionRideHeight.UShort(2));

                        Console.WriteLine("suspension ride height 3         " +
                                          telem.suspensionRideHeight.UShort(3));

                        Console.WriteLine("air pressure 0                   " +
                                          telem.airPressure.UShort(0));

                        Console.WriteLine("air pressure 1                   " +
                                          telem.airPressure.UShort(1));
                        
                        Console.WriteLine("air pressure 2                   " +
                                          telem.airPressure.UShort(2));

                        Console.WriteLine("air pressure 3                   " +
                                          telem.airPressure.UShort(3));

                        Console.WriteLine("engine speed                     " +
                                          telem.engineSpeed.Float());

                        Console.WriteLine("engine torque                    " +
                                          telem.engineTorque.Float());

                        Console.WriteLine("wings 0                          " +
                                          telem.wings.UInt(0));

                        Console.WriteLine("wings 1                          " +
                                          telem.wings.UInt(1));

                        Console.WriteLine("handbrake                        " +
                                          telem.handBrake.UInt());

                        Console.WriteLine("aero damage                      " +
                                          telem.aeroDamage.UInt());
                        
                        Console.WriteLine("engine damage                    " +
                                          telem.engineDamage.UInt());

                        Console.WriteLine("joy pad                          " +
                                          telem.joyPad0.UInt());

                        Console.WriteLine("d pad                            " +
                                          telem.dPad.UInt());

                        Console.WriteLine("d pad                            " +
                                          telem.dPad.UInt());

                        Console.WriteLine("tyre compond 0                   " +
                                          telem.tyreCompound.String(0));

                        Console.WriteLine("tyre compond 1                   " +
                                          telem.tyreCompound.String(1));

                        Console.WriteLine("tyre compond 2                   " +
                                          telem.tyreCompound.String(2));

                        Console.WriteLine("tyre compond 3                   " +
                                          telem.tyreCompound.String(3));

                        Console.WriteLine("turbo boost pressure             " +
                                          telem.turboBoostPressure.Float());
                        
                        Console.WriteLine("full position 0                  " +
                                          telem.fullPosition.Float(0));

                        Console.WriteLine("full position 1                  " +
                                          telem.fullPosition.Float(1));

                        Console.WriteLine("full position 2                  " +
                                          telem.fullPosition.Float(2));
                        
                        Console.WriteLine("brake bias                       " +
                                          telem.brakeBias.UInt());

                        Console.WriteLine("tick count                       " +
                                          telem.tickCount.UInt());
                    }
                   
                    // if (packetBase.packetType.UInt() == 3 && bytes.Length == 1063)
                    // disabled
                    if (packetBase.packetType.UInt() == 5555 && bytes.Length == 1063)
                    {
                        TimingsDataDecoder timing = new TimingsDataDecoder();
                        index = 0;
                        timing.Decode(ref bytes, ref index);

                        Console.WriteLine("num participants         " +
                                          timing.numParticipants.Int());

                        // No idea what this is but all participant packets have one
                        Console.WriteLine("changed timestamp        " +
                                          timing.participantsChangedTimestamp.UInt());

                        Console.WriteLine("split time ahead         " +
                                          timing.splitTimeAhead.Float());

                        Console.WriteLine("split time behind        " +
                                          timing.splitTimeBehind.Float());

                        Console.WriteLine("split time               " +
                                          timing.splitTime.Float());
                        
                        // Not sure which one is which
                        Console.WriteLine("world position 0         " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).worldPosition.Short(0));

                        Console.WriteLine("world position 1         " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).worldPosition.Short(1));

                        Console.WriteLine("world position 2         " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).worldPosition.Short(2));
                    
                        // Direction you are facing seems to go between 520-0
                        Console.WriteLine("orientation 0            " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).orientation.Short(0));

                        // these two might have something to do with pitch of the car?
                        Console.WriteLine("orientation 1            " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).orientation.Short(1));

                        Console.WriteLine("orientation 2            " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).orientation.Short(2));
                    
                        Console.WriteLine("current lap distance     " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).currentLapDistance.UShort());

                        Console.WriteLine("Is Active                " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).racePosition.IsActive());
                    
                        Console.WriteLine("Race Position            " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).racePosition.RacePosition());
                    
                        Console.WriteLine("Sector                   " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).sector.Sector());
                        
                        Console.WriteLine("Extra world x            " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).sector.XExtraPrecision());
                    
                        Console.WriteLine("Extra world z            " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).sector.ZExtraPrecision());
                        
                        Console.WriteLine("Flag Colours             " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).highestFlag.FlagColours());

                        Console.WriteLine("Flag Reason              " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).highestFlag.FlagReason());
                    
                        Console.WriteLine("Pit Mode                 " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).pitModeSchedule.PitMode());
                        
                        Console.WriteLine("Pit Schedule             " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).pitModeSchedule.PitSchedule());

                        // Car Index is broken waiting on patch
                        Console.WriteLine("Car Index                " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).carIndex.UShort());
                    
                        Console.WriteLine("Race State               " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).raceState.RaceState());
                        
                        Console.WriteLine("Invalid Lap              " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).raceState.InvalidLap());
                        
                        Console.WriteLine("Current Lap              " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).currentLap.UInt());

                        Console.WriteLine("Current Time             " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).currentTime.TimeStamp());

                        Console.WriteLine("Current Sector Time      " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).currentSectorTime.TimeStamp());

                        Console.WriteLine("Participant Index        " +
                                          timing.participants.ParticipantInfoArray(timing.localParticipantIndex.Short()).participantIndex.UShort());
                    
                    }
                }
            }
        }
    }
}
