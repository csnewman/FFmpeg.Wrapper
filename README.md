# FFmpeg.Wrapper
FFmpeg.Wrapper is a wrapper of FFmpeg built on top of [FFmpeg.AutoGen](https://github.com/Ruslan-B/FFmpeg.AutoGen). The purpose is to allow safe and easy access to ffmpeg in a standard C# fashion. 

Notice: Features are being added as needed, if you want something ported, please open an issue with the method names. An example in C/C++ of those methods being used would be appreciated to allow me to test whether it works. If you know how to port a feature, open a pull request!

## Getting Started
- You will need to download [FFmepg.AutoGen](https://github.com/Ruslan-B/FFmpeg.AutoGen)(You only need the FFmpeg.AutoGen folder, none of the others) and compile it.
- Next you will need to download this repo and add reference to your recently compiled dll and compile it.
- You will need to download the [zeranoe ffmpeg](https://ffmpeg.zeranoe.com/builds/) dlls, you will want the 32 and 64bit shared dlls. 

## Example
You can find an example [here](https://gist.github.com/csnewman/1459ed8c95632a5f22bb52b2f6c19f4a)
(Credit to the FFmpeg.AutoGen author, this code has been converted from their example code.)

If you have created something using FFmpeg.Wrapper please open an issue with a link and I'll add you to this file!
