# Toy Robot Simulator

## Overview

This Toy Robot Simulator is a simple console app written in C# that simulates the movement of a toy robot on a tabletop. The robot can be moved around the tabletop via user input.

## Features
- Can PLACE the robot on a 5x5 tabletop.
- Can MOVE the robot +1 step forward in the direction it's facing.
- Can turn the robot LEFT or RIGHT.
- Can REPORT the current position and direction of the robot.

## Non-Functional Requirements
**1. Language must be either C# or Typescript**

Written in C#.


**2. The application must be able to be deployed to a production environment for end-users**

Can create a .exe of the application through, which can then be transferred to the production environment:

```sh
dotnet publish -c Release -r win-x64 -o ./publish
```

Or if the runtime needs to be included for the target environment:

```sh
dotnet publish -c Release -r win-x64 --self-contained -o ./publish
```

**3. The application will need to be maintained by different developers during its life**

I've written this using 2 common design patterns: Command and Factory. Alongside this I *think* I have written fairly clean and straight forward code. Hopefully this will make it easy for other developers to maintain the application. I have also included a range of tests to aid future changes to the code base to ensure functionality remains the same.


**4. The application must be contained in a single git repository**

You're looking at it. :)


## Getting Started

### Prerequisites

- .NET 8.0 SDK or later installed on your machine.

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/fmg-dakota/ToyRobot.git
    cd ToyRobot/ToyRobot
    ```

2. Build the application:
    ```sh
    dotnet build
    ```

3. Run the application:
    ```sh
    dotnet run ToyRobot
    ```

### Usage

1. The application accepts the following commands:
    - `PLACE X,Y,F`: Places the robot on the table at position (X,Y) facing direction F (NORTH, SOUTH, EAST, or WEST).
    - `MOVE`: Moves the robot +1 forward in the direction it is currently facing.
    - `LEFT`: Turn the robot to the left.
    - `RIGHT`: Turn the robot to the right.
    - `REPORT`: Outputs the current position and direction of the robot.

2. Example usage:
    ```
    PLACE 0,0,NORTH
    MOVE
    REPORT
    Output: 0,1,NORTH
    [ ][ ][ ][ ][ ]
    [ ][ ][ ][ ][ ]
    [ ][ ][ ][ ][ ]
    [▲][ ][ ][ ][ ]
    [ ][ ][ ][ ][ ]
    ```

## Project Structure
```
ToyRobot/
├── ToyRobot/
│ ├── Models/
│ │ ├── Direction.cs
│ │ ├── Position.cs
│ │ ├── Robot.cs
│ │ ├── Tabletop.cs
│ ├── RobotCommands/
│ │ ├── IRobotCommand.cs
│ │ ├── Place.cs
│ │ ├── Move.cs
│ │ ├── TurnLeft.cs
│ │ ├── TurnRight.cs
│ │ ├── Report.cs
│ ├── AssemblyInfo.cs
│ ├── ToyRobot.sln
│ ├── ToyRobot.csproj
│ ├── Program.cs
│ ├── UI.cs
│ │
├── ToyRobotTests/
│ ├── MoveTests.cs
│ ├── PlaceTests.cs
│ ├── ReportTests.cs
│ ├── RobotCommandFactoryTests.cs
│ ├── RobotTests.cs
│ ├── TabletopTests.cs
│ ├── ToyRobotTests.csproj
│ ├── TurnLeftTests.cs
│ ├── TurnRightTests.cs
├── .gitignore
├── README.md
```

## Deployment

1. Publish the application:
    ```sh
    dotnet publish -c Release -o ./publish
    ```
    Or if the runtime needs to be included for the target environment:

    ```sh
    dotnet publish -c Release -r win-x64 --self-contained -o ./publish
    ```

2. Copy the contents of the `publish` folder to your production environment.

3. Run the application:
    ```sh
    ./ToyRobot.exe
