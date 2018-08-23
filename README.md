# Rough Idea Project Cars CSharp

## Description

This is work in progress, these are my first attempts at CSharp so I have a big learning curve.
I'm just going to add/change files as I go, so to build anything you will have to create your own local project.

No Guarantee this is going to work or be correct I'm just going to post code as I do minimal testing to get something to work i.e. small iterations and being concrete early.

Also have done a set of C++ Classes https://github.com/leroythelegend/rough_idea_project_cars

## Getting Started

## Capturing UDP packets

If you are interested in getting the raw packets and decoding them yourself just use these classes

# UDPBlockingReader 

Will wait/block until there is some data to read. I don't recommend using, this however if you really want something super simple and just want to decode some specific data go for it.

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

