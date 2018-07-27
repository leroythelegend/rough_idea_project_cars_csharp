# Rough Idea Project Cars CSharp

## Description

This is work in progress, these are my first attempts at CSharp so I have a big learning curve.
I'm just going to add/change files as I go, so to build anything you will have to create your own local project.

Also have done a set of C++ Classes https://github.com/leroythelegend/rough_idea_project_cars

## Contents

* [Reader WIP](#C-Reader)

## <a name="C-Reader"></a>Reader

Set of IReader Classes for reading UDP packets.

NOTE: I still need to think on the exception handling.

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
