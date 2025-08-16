# WinForms Downloads Organizer (MVP, OOP)

A Windows Forms application built using the MVP pattern and object-oriented principles to organize downloaded files dynamically.

## Features

- **Automatic Categorization:** Classifies files into Documents, Images, Videos, Audio, Installers, Archives, Code, and Other categories based on file extensions.
- **Dynamic Subfolders:** Creates subfolders for each file extension automatically within their category folder.
- **MVP Architecture:** Uses the Model-View-Presenter pattern for clean separation of UI and business logic.
- **Flexible & Extensible:** Easily extendable to support more file types or custom categorization rules.
- **.NET WinForms:** Compatible with .NET 6 or .NET 8 Windows Forms applications.

## Example Folder Structure

```
Downloads
│
├─ Documents
│  ├─ pdf
│  └─ docx
├─ Images
│  ├─ jpg
│  └─ png
├─ Archives
│  ├─ zip
│  └─ rar
└─ Code
   ├─ cs
   └─ py
```

## Usage

1. Set the root folder where your downloads are stored.
2. The application will scan the folder and move files into their respective category and extension folders.
3. Folders are created dynamically if they do not exist.

## Requirements

- Windows OS
- .NET 6 or .NET 8 with Windows Forms enabled

## License

MIT License
