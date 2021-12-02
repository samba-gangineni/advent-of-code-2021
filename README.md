# AdventOfCode 2021

## Requirements:

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

## Usage:

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
$ dotnet publish
# Change the configurations in Solve.csproj to get executables for different run times and os
```

### run the package

- Download the package `Solve` from aforementioned github repo.

Note: Naming convention for data files is `Day1Prob.txt`. You can download the data from the aforementioned repo

```bash
# Set environment variable to path where your data files are present
$ export AOC_2021_DATA="/Users/sambagangineni/Documents/samba-gangineni/AdventOfCode2021/data"
$ cd [Folder_where_package_is_downloaded]
# Ex: cd ~/Downloads
$ ./Solve [Day] [Problem]
```
