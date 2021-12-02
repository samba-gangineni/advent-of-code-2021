# AdventOfCode 2021

## Run using package

- Download the package `Solve-osx-x64` or `Solve-win-x64.exe` from [here](https://github.com/samba-gangineni/advent-of-code-2021/releases)

Note: Naming convention for data files is `Day1Prob.txt`. You can download the data from the [here](https://github.com/samba-gangineni/advent-of-code-2021/tree/main/data)

```bash
# Set environment variable to path where your data files are present for mac
$ export AOC_2021_DATA="/Users/sambagangineni/Documents/samba-gangineni/AdventOfCode2021/data"

# Adding environment variable in windows:
$ set AOC_2021_DATA="C:\Users\sambagangineni\Documents\samba-gangineni\AdventOfCode2021\data"

$ cd [Folder_where_package_is_downloaded]
# Ex: cd ~/Downloads

$ chmod a+x Solve-osx-64
$ ./Solve-osx-x64 [Day] [Problem] # for mac

$ Solve-win-x64.exe [Day] [Problem] # for windows
```

## Run using the repo:

### Prerequisites:

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) (If you are running from cloning the repo)
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

### Clone the repo

```bash
$ git clone https://github.com/samba-gangineni/advent-of-code-2021.git
```

### run the project

```bash
$ cd advent-of-code-2021
$ dotnet run --project Solve/Solve.csproj [Day] [Problem]
# [Day]: 1 - 25
# [Prob]: 1 - 2
```

### publish the project

```bash
$ dotnet publish --Configuration Release
# Change the configurations in Solve.csproj to get executables for different run times and os
```
