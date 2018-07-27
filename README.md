# Rough Idea Project Cars CSharp

## Description

This is work in progress, these are my first attempts at CSharp so I have a big learning curve.
I'm just going to add/change files as I go, so to build anything you will have to create your own local project.

Also have done a set of C++ Classes https://github.com/leroythelegend/rough_idea_project_cars

## Contents

* [Reader WIP](#C-Reader)

## <a name="C-Reader"></a>Reader

### UDPBlockingReader

```
  // Create a UDPBlockingReader object with the port number you want to bind to
  // Project Cars UDP uses port number 5606
  UDPBlockingReader reader = new UDPBlockingReader(5606);
  
  // Call Read, this will block i.e. will not return until there is something to return i.e. read
  Byte[] bytes = reader.Read();
```
