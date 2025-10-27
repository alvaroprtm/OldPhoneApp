# OldPhoneApp

Small C# console app that decodes input from an old phone keypad (multi-press).  
This repo is intentionally minimal and runnable so a reviewer can open the solution in Visual Studio or build from the command line.

Project files
- `OldPhoneApp.sln` — Visual Studio solution (VS2022)
- `OldPhoneApp.csproj` — project file (target: .NET Framework 4.7.2, C# 7.3)
- `Program.cs` — example runner that calls the decoder
- `OldPhonePad.cs` — decoder logic (simple, junior-friendly implementation)
- `README.md` — this file

How it works (short)
- Digits `2`–`9` map to letters (standard phone mapping).
- `0` produces a space.
- Repeating the same digit cycles through the letters on that key; a space in the input acts as a pause to commit the current character.
- `*` acts as backspace (commits pending presses first, then removes last character).
- `#` is the send/terminator: every input should end with `#`.

Example inputs (as included in `Program.cs`)
- `OldPhonePad.Decode("33#")` => `E`
- `OldPhonePad.Decode("227*#")` => `B`
- `OldPhonePad.Decode("4433555 555666#")` => `HELLO`
- `OldPhonePad.Decode("8 88777444666*664#")` => `TURING` (example sequence)

Build & run (Visual Studio)
1. Open the solution in Visual Studio 2022.
2. Press __F5__ (or __Debug > Start Debugging__) to run.
3. Use __Solution Explorer__ to inspect `Program.cs` and `OldPhonePad.cs`.

Build & run (command line)
1. Open the "Developer Command Prompt for VS 2022".
2. From the repo root run:
   - `msbuild OldPhoneApp.csproj`
   - Run the produced executable in the `bin\Debug` (or `bin\Release`) folder.

Tips
- Keep the `.sln` and `.csproj` in the repo for easy review so reviewers can open and run the project immediately.
- If you need a minimal submission, provide only `Program.cs`, `OldPhonePad.cs`, and this `README.md` and include build instructions.

If you want, I can:
- Add a small unit-test project, or
- Produce a minimal repo layout containing only the two
