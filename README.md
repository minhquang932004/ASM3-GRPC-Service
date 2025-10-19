# FA25_PRN232_SE1717_ASM3_184116_QuangNM

## Overview

This project demonstrates a gRPC service implementation in C# (.NET 8) for electric vehicle management. It provides endpoints for greeting and managing promotions using Protocol Buffers for efficient communication.

## What is gRPC?

gRPC is a high-performance, open-source RPC (Remote Procedure Call) framework developed by Google. It uses HTTP/2 for transport, Protocol Buffers for serialization, and provides features like streaming, authentication, and bidirectional communication. gRPC is ideal for microservices and distributed systems due to its speed and language interoperability.

## Project Structure

- **ElectricVehicleM.GrpcService.QuangNM**: Main gRPC service project.
- **Protos**: Contains `.proto` files defining service contracts and message types.
- **Services**: Contains service implementations (`GreeterService`, `PromotionsQuangNmGRPCService`).
- **ElectricVehicleM.Services.QuangNM**: Business logic and data access layer.

## How gRPC Works in This Project

1. **Define Service Contracts**:  
   Service interfaces and messages are defined in `.proto` files (e.g., `greet.proto`, `PromotionsQuangNm.proto`).

2. **Generate C# Code**:  
   The project uses the `Protobuf` MSBuild integration to generate C# classes from `.proto` files at build time.

3. **Implement Services**:  
   - `GreeterService`: Simple greeting endpoint.
   - `PromotionsQuangNmGRPCService`: Provides promotion-related operations.

4. **Configure gRPC in ASP.NET Core**:  
   In `Program.cs`, gRPC services are registered and mapped to endpoints.

## Setup Instructions
Enter this in GRPC service project: dotnet add package protobuf-net

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (recommended)
- Git
