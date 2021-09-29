# Protocol_Source_File
Create a [protocol_source.json](./protocol_source.json) file to edit protocol structures


Supported types:


| Protocol | C#  |
| :----:  | :----: |
| int32 | int |
|uint32  |uint  |
|int16  |short  |
|uint16  |ushort  |
|byte  |byte  |
|int64  |long  |
|uint64  |ulong  |
|float  |float  |
|double  |double  |
|string  |string  |
|bool  |bool  |




# How to generate protocol structures?

```shell
Generator.exe -s [protocol_source_file_path] -o [output_folder_path]
```
# Generated data structures
## Example generated from a [protocol_source.json](./protocol_source.json)
* [PtInt32List.cs](./output/PtInt32List.cs)
* [PtRoomList.cs](./output/PtRoomList.cs)
* [PtRoom.cs](./output/PtRoom.cs)
* [PtRoomPlayer.cs](./output/PtRoomPlayer.cs)

# How to use protocol structures?
## Array format For example PtInt32List:

```csharp
PtInt32List int32List = new PtInt32List();
int32List.SetElements(new List<int>() { 0, 1, 2, 3, 4, 5, 6 });
byte[] bytes = PtInt32List.Write(int32List);
File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, "int32list.bin"),bytes);
//----Binary data in int32list.bin----
//0107 0000 0000 0000 0001 0000 0002 0000
//0003 0000 0004 0000 0005 0000 0006 0000
//00 


PtInt32List newInt32List = PtInt32List.Read( File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "int32list.bin")));
Console.WriteLine(string.Join(" ", newInt32List.Elements)); // 0 1 2 3 4 5 6
```

## Nested structure for exmaple  PtRoomList:

```csharp
PtRoomList ptRoomList = new PtRoomList();
List<PtRoom> ptRooms = new List<PtRoom>();
PtRoom room = new PtRoom();
room.SetMapId(100);
room.SetMaxPlayerCount(12);
List<PtRoomPlayer> ptRoomPlayers = new List<PtRoomPlayer>();
PtRoomPlayer ptRoomPlayer = new PtRoomPlayer();
ptRoomPlayer.Setheight(20.3f);
ptRoomPlayer.SetEnable(true);
ptRoomPlayer.SetEntityId(2001);
ptRoomPlayer.SetNickName("Jerry");
ptRoomPlayer.SetPassword("*123");
ptRoomPlayer.Setpower(39999.4455);
ptRoomPlayer.SetStatus(30);
ptRoomPlayer.SetTeamId(1);
ptRoomPlayer.SetUserId(93999);
ptRoomPlayer.SetUUID(99999999999);
ptRoomPlayers.Add(ptRoomPlayer);
room.SetPlayers(ptRoomPlayers);
room.SetRoomId(3);
room.SetRoomOwnerUserId("room user abc");
room.SetStatus(20);
ptRooms.Add(room);
ptRoomList.SetRooms(ptRooms);
var bytes = PtRoomList.Write(ptRoomList);
File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, "roomList.bin"), bytes);
//----Binary data in roomList.bin----
//0101 0000 0000 523f 0300 0000 1464 0000
//0000 0d72 6f6f 6d20 7573 6572 2061 6263
//0c01 0000 0000 32ff 03d1 0700 0001 0005
//4a65 7272 792f 6f01 0000 0000 00ff e776
//4817 0000 0000 042a 3132 331e 0166 66a2
//414c 3789 41ee 87e3 40
var newRoomList = PtRoomList.Read(bytes);
```

