
// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: tokenizer_maps.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from tokenizer_maps.proto</summary>
public static partial class TokenizerMapsReflection {

  #region Descriptor
  /// <summary>File descriptor for tokenizer_maps.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static TokenizerMapsReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChR0b2tlbml6ZXJfbWFwcy5wcm90byLWAwoNVG9rZW5pemVyTWFwcxIsCgdU",
          "ZXh0TWFwGAEgAygLMhsuVG9rZW5pemVyTWFwcy5UZXh0TWFwRW50cnkSOAoN",
          "U3BlY2lhbFRva2VucxgCIAMoCzIhLlRva2VuaXplck1hcHMuU3BlY2lhbFRv",
          "a2Vuc0VudHJ5EiwKB1JhbmtNYXAYAyADKAsyGy5Ub2tlbml6ZXJNYXBzLlJh",
          "bmtNYXBFbnRyeRJGChRJbnZlcnNlU3BlY2lhbFRva2VucxgEIAMoCzIoLlRv",
          "a2VuaXplck1hcHMuSW52ZXJzZVNwZWNpYWxUb2tlbnNFbnRyeRIUCgxSZWdl",
          "eFBhdHRlcm4YBSABKAkaLgoMVGV4dE1hcEVudHJ5EgsKA2tleRgBIAEoBRIN",
          "CgV2YWx1ZRgCIAEoDDoCOAEaNAoSU3BlY2lhbFRva2Vuc0VudHJ5EgsKA2tl",
          "eRgBIAEoCRINCgV2YWx1ZRgCIAEoBToCOAEaLgoMUmFua01hcEVudHJ5EgsK",
          "A2tleRgBIAEoCRINCgV2YWx1ZRgCIAEoBToCOAEaOwoZSW52ZXJzZVNwZWNp",
          "YWxUb2tlbnNFbnRyeRILCgNrZXkYASABKAUSDQoFdmFsdWUYAiABKAw6AjgB",
          "YgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::TokenizerMaps), global::TokenizerMaps.Parser, new[]{ "TextMap", "SpecialTokens", "RankMap", "InverseSpecialTokens", "RegexPattern" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { null, null, null, null, })
        }));
  }
  #endregion

}
#region Messages
public sealed partial class TokenizerMaps : pb::IMessage<TokenizerMaps>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<TokenizerMaps> _parser = new pb::MessageParser<TokenizerMaps>(() => new TokenizerMaps());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<TokenizerMaps> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::TokenizerMapsReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public TokenizerMaps() {
    OnConstruction();
  }

  partial void OnConstruction();
