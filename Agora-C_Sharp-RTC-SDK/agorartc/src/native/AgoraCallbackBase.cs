//  AgoraCallbackBase.cs
//
//  Created by YuGuo Chen on September 27, 2021.
//
//  Copyright © 2021 Agora. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace agora.rtc
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_Bool_Natvie();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate uint Func_Uint32_t_Native();


    //event_handler
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_Event_Native(string @event, string data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_EventWithBuffer_Native(string @event, string data, IntPtr buffer, uint length);


    //audio_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameLocal_Native(IntPtr audio_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameRemote_Native(uint uid, IntPtr audio_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_AudioFrameEx_Native(string channel_id, uint uid, IntPtr audio_frame);


    //video_frame
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameLocal_Native(IntPtr video_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoCaptureLocal_Native(IntPtr video_frame, VideoSourceType source_type);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameMediaPlayer_Native(IntPtr videoFrame, int mediaPlayerId);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameRemote_Native(uint uid, IntPtr video_frame);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_VideoFrameEx_Native(string channel_id, uint uid, IntPtr video_frame);

    // [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    // internal delegate VIDEO_FRAME_TYPE Func_VideoFrameType_Native();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate void Func_VideoFrame_Native(IntPtr video_frame, uint uid, string channel_id, bool resize);

    //encoded_video_image
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate bool Func_EncodedVideoImageReceived_Native(IntPtr imageBuffer, UInt64 length, IntPtr videoEncodedFrameInfo);

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCVideoEncodedImageReceiverNative {
        internal IntPtr OnEncodedVideoImageReceived;
    }

    internal struct IrisRtcCVideoEncodedImageReceiver {
        internal Func_EncodedVideoImageReceived_Native OnEncodedVideoImageReceived;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCEventHandlerNative
    {
        internal IntPtr onEvent;
        internal IntPtr onEventWithBuffer;
    }
    
    internal struct IrisCEventHandler
    {
        internal Func_Event_Native OnEvent;
        internal Func_EventWithBuffer_Native OnEventWithBuffer;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCAudioFrameObserverNative
    {
        internal IntPtr OnRecordAudioFrame;
        internal IntPtr OnPlaybackAudioFrame;
        internal IntPtr OnMixedAudioFrame;
        internal IntPtr OnPlaybackAudioFrameBeforeMixing;
        internal IntPtr IsMultipleChannelFrameWanted;
        internal IntPtr OnPlaybackAudioFrameBeforeMixingEx;
    }

    internal struct IrisRtcCAudioFrameObserver
    {
        internal Func_AudioFrameLocal_Native OnRecordAudioFrame;
        internal Func_AudioFrameLocal_Native OnPlaybackAudioFrame;
        internal Func_AudioFrameLocal_Native OnMixedAudioFrame;
        internal Func_AudioFrameRemote_Native OnPlaybackAudioFrameBeforeMixing;
        internal Func_Bool_Natvie IsMultipleChannelFrameWanted;
        internal Func_AudioFrameEx_Native OnPlaybackAudioFrameBeforeMixingEx;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisRtcCVideoFrameObserverNative
    {
        internal IntPtr OnCaptureVideoFrame;
        internal IntPtr OnMediaPlayerVideoFrame;
        internal IntPtr OnPreEncodeVideoFrame;
        internal IntPtr OnRenderVideoFrame;
        internal IntPtr GetObservedFramePosition;
        internal IntPtr IsMultipleChannelFrameWanted;
        internal IntPtr OnRenderVideoFrameEx;
    }
    
    internal struct IrisRtcCVideoFrameObserver
    {
        internal Func_VideoCaptureLocal_Native OnCaptureVideoFrame;
        internal Func_VideoFrameMediaPlayer_Native OnMediaPlayerVideoFrame;
        internal Func_VideoFrameLocal_Native OnPreEncodeVideoFrame;
        internal Func_VideoFrameRemote_Native OnRenderVideoFrame;
        internal Func_Uint32_t_Native GetObservedFramePosition;
        internal Func_Bool_Natvie IsMultipleChannelFrameWanted;
        internal Func_VideoFrameEx_Native OnRenderVideoFrameEx;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct IrisCVideoFrameBufferNative
    {
        internal int type;
        internal IntPtr OnVideoFrameReceived;
        internal int resize_width;
        internal int resize_height;
    }
    
    internal struct IrisCVideoFrameBuffer
    {
        internal VIDEO_FRAME_TYPE type;
        internal Func_VideoFrame_Native OnVideoFrameReceived;
        internal int resize_width;
        internal int resize_height;
    }
}