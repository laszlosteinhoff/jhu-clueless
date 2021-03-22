del ..\server\grpc\*pb2*
del ..\Clueless\Assets\Scripts\Generated\*.cs
python -m grpc_tools.protoc -I. --python_out=..\server\generated_sources --grpc_python_out=..\server\generated_sources Network.proto
Rem ..\Clueless\Packages\Grpc.Tools.2.36.1\tools\windows_x64\protoc -I=. --csharp_out=..\Clueless\Assets\Scripts\Grpc\ Network.proto
..\Clueless\Assets\Plugins\grpc-protoc_windows_x64-1.26.0-dev\protoc -I=. ^
--csharp_out=..\Clueless\Assets\Scripts\Generated\ ^
--grpc_out=..\Clueless\Assets\Scripts\Generated\ ^
--plugin=protoc-gen-grpc=..\Clueless\Assets\Plugins\grpc-protoc_windows_x64-1.26.0-dev\grpc_csharp_plugin.exe ^
Network.proto