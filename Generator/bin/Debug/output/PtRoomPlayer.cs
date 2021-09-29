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
