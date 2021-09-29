# Protocol_Source_File
Create a json file to edit protocol structures

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





[protocol_source](./protocol_source.json)

```json
{	
    "using_ns":["Protocol.Net"],
    "ns":"Development.Net.Pt",
    "pts": [								
			{
				"className": "PtInt32List",
				"fields": [
					{
						"type": "int32",
						"name": "Elements",
						"isArray": 1
					}
				]
			},			
			{
				"className": "PtRoomList",
				"fields": [
					{
						"type": "PtRoom",
						"name": "Rooms",
						"isArray": 1
					}
				]
			},
			{
				"className": "PtRoom",
				"fields": [
					{
						"type": "uint32",
						"name": "RoomId"
					},
					{
						"type": "byte",
						"name": "Status"
					},
					{
						"type": "uint32",
						"name": "MapId"
					},
					{
						"type": "string",
						"name": "RoomOwnerUserId"
					},
					{
						"type": "byte",
						"name": "MaxPlayerCount"
					},
					{
						"type": "PtRoomPlayer",
						"name": "Players",
						"isArray": 1
					}
				]
			},
			{
				"className": "PtRoomPlayer",
				"fields": [
					{
						"type": "uint32",
						"name": "EntityId"
					},
					{
						"type": "byte",
						"name": "TeamId"
					},
					{
						"type": "string",
						"name": "NickName"
					},
					{
						"type": "int64",
						"name": "UserId"
					},
					{
						"type": "uint64",
						"name": "UUID"
					},
					{
						"type": "string",
						"name": "Password"
					},
					{
						"type": "byte",
						"name": "Status"
					},
					{
						"type": "bool",
						"name": "Enable"
					},
					{
						"type": "float",
						"name": "height"
					}
					,
					{
						"type":"double",
						"name":"power"
					}
				]
			}
    ]
}
```

# How to generate protocol structures?

```shell
Generator.exe -s [protocol_source_file_path] -o [output_folder_path]
```
# Generated data structures
### PtInt32List.cs
```csharp
//Creation time:2021/9/29 11:29:46
using System;
using System.Collections;
using System.Collections.Generic;
using Protocol.Net;

namespace Development.Net.Pt
{
public class PtInt32List
{
    public byte __tag__ { get;private set;}

	public List<int> Elements{ get;private set;}
	   
    public PtInt32List SetElements(List<int> value){Elements=value; __tag__|=1; return this;}
	
    public bool HasElements(){return (__tag__&1)==1;}
	
    public static byte[] Write(PtInt32List data)
    {
        using(ByteBuffer buffer = new ByteBuffer())
        {
            buffer.WriteByte(data.__tag__);
			if(data.HasElements())buffer.WriteCollection(data.Elements,element=>buffer.WriteInt32(element));
			
            return buffer.GetRawBytes();
        }
    }

    public static PtInt32List Read(byte[] bytes)
    {
        using(ByteBuffer buffer = new ByteBuffer(bytes))
        {
            PtInt32List data = new PtInt32List();
            data.__tag__ = buffer.ReadByte();
			if(data.HasElements())data.Elements = buffer.ReadCollection(()=>buffer.ReadInt32());
			
            return data;
        }       
    }
}
}
```

### PtRoomList.cs
```csharp
//Creation time:2021/9/29 11:29:46
using System;
using System.Collections;
using System.Collections.Generic;
using Protocol.Net;

namespace Development.Net.Pt
{
public class PtRoomList
{
    public byte __tag__ { get;private set;}

	public List<PtRoom> Rooms{ get;private set;}
	   
    public PtRoomList SetRooms(List<PtRoom> value){Rooms=value; __tag__|=1; return this;}
	
    public bool HasRooms(){return (__tag__&1)==1;}
	
    public static byte[] Write(PtRoomList data)
    {
        using(ByteBuffer buffer = new ByteBuffer())
        {
            buffer.WriteByte(data.__tag__);
			if(data.HasRooms())buffer.WriteCollection(data.Rooms,element=>PtRoom.Write(element));
			
            return buffer.GetRawBytes();
        }
    }

    public static PtRoomList Read(byte[] bytes)
    {
        using(ByteBuffer buffer = new ByteBuffer(bytes))
        {
            PtRoomList data = new PtRoomList();
            data.__tag__ = buffer.ReadByte();
			if(data.HasRooms())data.Rooms = buffer.ReadCollection(retbytes=>PtRoom.Read(retbytes));
			
            return data;
        }       
    }
}
}

```

### PtRoom.cs
```csharp
//Creation time:2021/9/29 11:29:46
using System;
using System.Collections;
using System.Collections.Generic;
using Protocol.Net;

namespace Development.Net.Pt
{
public class PtRoom
{
    public byte __tag__ { get;private set;}

	public uint RoomId{ get;private set;}
	public byte Status{ get;private set;}
	public uint MapId{ get;private set;}
	public string RoomOwnerUserId{ get;private set;}
	public byte MaxPlayerCount{ get;private set;}
	public List<PtRoomPlayer> Players{ get;private set;}
	   
    public PtRoom SetRoomId(uint value){RoomId=value; __tag__|=1; return this;}
	public PtRoom SetStatus(byte value){Status=value; __tag__|=2; return this;}
	public PtRoom SetMapId(uint value){MapId=value; __tag__|=4; return this;}
	public PtRoom SetRoomOwnerUserId(string value){RoomOwnerUserId=value; __tag__|=8; return this;}
	public PtRoom SetMaxPlayerCount(byte value){MaxPlayerCount=value; __tag__|=16; return this;}
	public PtRoom SetPlayers(List<PtRoomPlayer> value){Players=value; __tag__|=32; return this;}
	
    public bool HasRoomId(){return (__tag__&1)==1;}
	public bool HasStatus(){return (__tag__&2)==2;}
	public bool HasMapId(){return (__tag__&4)==4;}
	public bool HasRoomOwnerUserId(){return (__tag__&8)==8;}
	public bool HasMaxPlayerCount(){return (__tag__&16)==16;}
	public bool HasPlayers(){return (__tag__&32)==32;}
	
    public static byte[] Write(PtRoom data)
    {
        using(ByteBuffer buffer = new ByteBuffer())
        {
            buffer.WriteByte(data.__tag__);
			if(data.HasRoomId())buffer.WriteUInt32(data.RoomId);
			if(data.HasStatus())buffer.WriteByte(data.Status);
			if(data.HasMapId())buffer.WriteUInt32(data.MapId);
			if(data.HasRoomOwnerUserId())buffer.WriteString(data.RoomOwnerUserId);
			if(data.HasMaxPlayerCount())buffer.WriteByte(data.MaxPlayerCount);
			if(data.HasPlayers())buffer.WriteCollection(data.Players,element=>PtRoomPlayer.Write(element));
			
            return buffer.GetRawBytes();
        }
    }

    public static PtRoom Read(byte[] bytes)
    {
        using(ByteBuffer buffer = new ByteBuffer(bytes))
        {
            PtRoom data = new PtRoom();
            data.__tag__ = buffer.ReadByte();
			if(data.HasRoomId())data.RoomId = buffer.ReadUInt32();
			if(data.HasStatus())data.Status = buffer.ReadByte();
			if(data.HasMapId())data.MapId = buffer.ReadUInt32();
			if(data.HasRoomOwnerUserId())data.RoomOwnerUserId = buffer.ReadString();
			if(data.HasMaxPlayerCount())data.MaxPlayerCount = buffer.ReadByte();
			if(data.HasPlayers())data.Players = buffer.ReadCollection(retbytes=>PtRoomPlayer.Read(retbytes));
			
            return data;
        }       
    }
}
}

```

### PtRoomPlayer.cs
```csharp
//Creation time:2021/9/29 11:29:46
using System;
using System.Collections;
using System.Collections.Generic;
using Protocol.Net;

namespace Development.Net.Pt
{
public class PtRoomPlayer
{
    public ushort __tag__ { get;private set;}

	public uint EntityId{ get;private set;}
	public byte TeamId{ get;private set;}
	public string NickName{ get;private set;}
	public long UserId{ get;private set;}
	public ulong UUID{ get;private set;}
	public string Password{ get;private set;}
	public byte Status{ get;private set;}
	public bool Enable{ get;private set;}
	public float height{ get;private set;}
	public double power{ get;private set;}
	   
    public PtRoomPlayer SetEntityId(uint value){EntityId=value; __tag__|=1; return this;}
	public PtRoomPlayer SetTeamId(byte value){TeamId=value; __tag__|=2; return this;}
	public PtRoomPlayer SetNickName(string value){NickName=value; __tag__|=4; return this;}
	public PtRoomPlayer SetUserId(long value){UserId=value; __tag__|=8; return this;}
	public PtRoomPlayer SetUUID(ulong value){UUID=value; __tag__|=16; return this;}
	public PtRoomPlayer SetPassword(string value){Password=value; __tag__|=32; return this;}
	public PtRoomPlayer SetStatus(byte value){Status=value; __tag__|=64; return this;}
	public PtRoomPlayer SetEnable(bool value){Enable=value; __tag__|=128; return this;}
	public PtRoomPlayer Setheight(float value){height=value; __tag__|=256; return this;}
	public PtRoomPlayer Setpower(double value){power=value; __tag__|=512; return this;}
	
    public bool HasEntityId(){return (__tag__&1)==1;}
	public bool HasTeamId(){return (__tag__&2)==2;}
	public bool HasNickName(){return (__tag__&4)==4;}
	public bool HasUserId(){return (__tag__&8)==8;}
	public bool HasUUID(){return (__tag__&16)==16;}
	public bool HasPassword(){return (__tag__&32)==32;}
	public bool HasStatus(){return (__tag__&64)==64;}
	public bool HasEnable(){return (__tag__&128)==128;}
	public bool Hasheight(){return (__tag__&256)==256;}
	public bool Haspower(){return (__tag__&512)==512;}
	
    public static byte[] Write(PtRoomPlayer data)
    {
        using(ByteBuffer buffer = new ByteBuffer())
        {
            buffer.WriteUInt16(data.__tag__);
			if(data.HasEntityId())buffer.WriteUInt32(data.EntityId);
			if(data.HasTeamId())buffer.WriteByte(data.TeamId);
			if(data.HasNickName())buffer.WriteString(data.NickName);
			if(data.HasUserId())buffer.WriteInt64(data.UserId);
			if(data.HasUUID())buffer.WriteUInt64(data.UUID);
			if(data.HasPassword())buffer.WriteString(data.Password);
			if(data.HasStatus())buffer.WriteByte(data.Status);
			if(data.HasEnable())buffer.WriteBool(data.Enable);
			if(data.Hasheight())buffer.WriteFloat(data.height);
			if(data.Haspower())buffer.WriteDouble(data.power);
			
            return buffer.GetRawBytes();
        }
    }

    public static PtRoomPlayer Read(byte[] bytes)
    {
        using(ByteBuffer buffer = new ByteBuffer(bytes))
        {
            PtRoomPlayer data = new PtRoomPlayer();
            data.__tag__ = buffer.ReadUInt16();
			if(data.HasEntityId())data.EntityId = buffer.ReadUInt32();
			if(data.HasTeamId())data.TeamId = buffer.ReadByte();
			if(data.HasNickName())data.NickName = buffer.ReadString();
			if(data.HasUserId())data.UserId = buffer.ReadInt64();
			if(data.HasUUID())data.UUID = buffer.ReadUInt64();
			if(data.HasPassword())data.Password = buffer.ReadString();
			if(data.HasStatus())data.Status = buffer.ReadByte();
			if(data.HasEnable())data.Enable = buffer.ReadBool();
			if(data.Hasheight())data.height = buffer.ReadFloat();
			if(data.Haspower())data.power = buffer.ReadDouble();
			
            return data;
        }       
    }
}
}


```

# How to use protocol structures?
Array format For example PtInt32List:
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

Nested structure for exmaple  PtRoomList:

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

