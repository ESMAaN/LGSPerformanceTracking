# 📊 DesktopApp – LGS Performance Tracking System

**DesktopApp** is a Windows Forms application designed to help students and educators track performance in Turkey’s High School Entrance Exam (LGS).  
It provides tools for managing student results, visualizing trends, importing scanned PDFs via OCR, and generating printable reports with RDLC.

---

## 🚀 Features

- Add exams and scores manually or via OCR from PDF/image
- View detailed charts (line, bar, pie)
- Analyze student performance trends over time
- Admin and student-specific dashboards
- Generate downloadable reports using RDLC
- Import exam results from external schools

---

## 🛠️ Technologies & Libraries Used

- **C# / .NET Framework** – Main programming platform
- **SQL Server** – (Optional) stores student and exam data
- **Tesseract OCR** – Extracts data from scanned exam PDFs/images
- **Microsoft RDLC ReportViewer** – Generates printable student reports
- **System.Drawing**, **OpenFileDialog**, **DataGridView**, etc.

---

## 📚 External Dependencies

### 🔠 OCR Support with Tesseract

Used for scanning and extracting text from PDF or image-based exam documents.

📦 **Install via NuGet:**
```bash
Install-Package Tesseract
```

📂 **Required Files:**
```text
OCR/
├── Tesseract.dll
└── tessdata/
    └── tur.traineddata
```

Ensure `tessdata/` is located in the root or `bin/Debug` folder. `tur.traineddata` enables Turkish OCR.

---

### 📊 RDLC Report Generation

Used to generate printable reports of exam performance.

📦 **Install via NuGet:**
```bash
Install-Package Microsoft.Reporting.WinForms
```

📁 **Template File:**
```
ReportTemplates/
└── StudentReport.rdlc
```

RDLC is bound to `StudentExamReportDataSet.xsd` for structured data display.

---

## 📄 PDF Import via OCR

The app includes an OCR-powered import feature that reads exam results from PDFs and images:

### How It Works:

1. Click `Import OCR` button
2. Select a `.pdf`, `.jpg`, `.png`, or `.bmp` file
3. The image is scanned using Tesseract with Turkish language support
4. Extracted text is auto-parsed into exam fields
5. User can review/edit before saving

### Sample OCR Code

```csharp
using (var engine = new TesseractEngine("./tessdata", "tur", EngineMode.Default))
{
    using (var img = Pix.LoadFromFile(selectedFile))
    using (var page = engine.Process(img))
    {
        string ocrText = page.GetText();
        // Parse text and fill DataGridView
    }
}
```

---

## 📁 Project Structure

```text
DesktopApp/
├── App.config
├── Program.cs
├── Forms/
│   ├── Form1.cs / .Designer.cs / .resx
├── Dashboards/
│   ├── StudentDashboard.cs / .Designer.cs / .resx
├── Reports/
│   ├── StudentExamReportDataSet.cs / .xsd / .xsc / .xss
├── SplashScreen/
│   ├── SplashScreen.cs / .Designer.cs / .resx
├── OCR/
│   ├── Tesseract.dll
│   └── tessdata/
│       └── tur.traineddata
├── ReportTemplates/
│   └── StudentReport.rdlc
├── LICENSE
└── README.md
```

---

## ▶️ Getting Started

### Prerequisites
- Visual Studio 2019 or newer
- .NET Framework 4.x
- SQL Server Express or LocalDB (optional for storing results)


## 📄 License

This project is licensed under the [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0).  
© 2025 Esma Şen. All rights reserved.

---

## 📬 Contact

For questions, contributions or collaborations:

- 📧 Email: esmaasen5734@gmail.com  
- 🐙 GitHub: [github.com/ESMAaN](https://github.com/ESMAaN)

