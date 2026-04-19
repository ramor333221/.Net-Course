# 🎵 MusicRuchama API

**MusicRuchama** הוא ממשק Backend (API) חזק לניהול מרכז לימודי מוזיקה. המערכת מאפשרת ניהול מקיף של תלמידים, מורים ומערך שיעורים, תוך הקפדה על אבטחת מידע והרשאות גישה מתקדמות.

## 🛠 טכנולוגיות וכלים
* **Framework:** .NET 8.0 (C#)
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Security:** JWT (JSON Web Token) Authentication
* **Mapping:** AutoMapper
* **API Documentation:** Swagger / OpenAPI

---

## 🏗 ארכיטקטורת המערכת
הפרויקט בנוי במבנה שכבות (Layered Architecture) המפריד בין הלוגיקה העסקית לבין הגישה לנתונים:
1.  **API Layer:** ה-Controllers המטפלים בבקשות HTTP.
2.  **Service Layer:** שכבת הלוגיקה שבה מתבצעים העיבודים והחישובים.
3.  **Core Layer:** מכילה את הישויות (Entities), הממשקים (Interfaces) וה-DTOs.
4.  **Data Layer:** שכבת הגישה למסד הנתונים (SQL Server).

---

## 🔒 אבטחה והרשאות (Authorization)
הגישה למשאבים השונים מוגבלת לפי תפקיד המשתמש (`Role`):
* **Admin/Teacher:** הרשאה לנהל מורים, לעדכן שיעורים ולצפות בכל הנתונים.
* **Student:** הרשאה לצפות בנתונים הרלוונטיים בלבד (כמו שיעורים אישיים).

---

## ⚙️ התקנה והרצה (Setup)

### 1. קביעת מחרוזת חיבור (Connection String)
יש לעדכן את הקובץ `appsettings.json` בתיקיית ה-API:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=
