"Voltra"

پروژه "Voltra" یک فروشگاه آنلاین مبتنی بر "ASP.NET Core Web API" است که با تمرکز بر طراحی ساختاریافته، تفکیک مسئولیت‌ها، قابلیت نگهداری و توسعه‌پذیری پیاده‌سازی شده است.

این پروژه با رویکردی عملی برای توسعه "Backend" طراحی شده و در طول توسعه، قابلیت‌ها و بخش‌های مختلف آن به‌صورت تدریجی گسترش پیدا می‌کنند.

معماری

"Backend" پروژه بر پایه اصول "Clean Architecture" طراحی شده و مسئولیت‌های مختلف برنامه در لایه‌های مجزا قرار گرفته‌اند.


تکنولوژی‌ها

- "C#"
- ".NET 8"
- "ASP.NET Core Web API"
- "Entity Framework Core"
- "SQL Server"
- "Dapper"
- "ASP.NET Core Identity"
- "JWT Authentication"
- "Refresh Token"
- "Swagger / OpenAPI"

الگوها و اصول مورد استفاده

در توسعه پروژه از الگوها و اصول مختلفی برای ایجاد ساختاری قابل نگهداری و توسعه‌پذیر استفاده شده است:

- "Clean Architecture"
- "CQRS"
- "Repository Pattern"
- "Generic Repository"
- "Dependency Injection"
- "FluentValidation"
- "AutoMapper"

ساختار پروژه

"Solution" به چند لایه اصلی تقسیم شده است تا منطق کسب‌وکار از زیرساخت و لایه ارائه سرویس مستقل باشد.

"Domain"

شامل "Entity"ها، مفاهیم اصلی "Domain" و "Abstraction"های مرتبط با آن است.

"Application"

شامل "Feature"ها، منطق مربوط به "Application"، "DTO"ها، "Validation"ها و "Abstraction"های مورد نیاز "Application" است.

"Infrastructure"

شامل پیاده‌سازی "Repository"ها، دسترسی به داده‌ها، احراز هویت، "Data Protection" و سایر وابستگی‌های زیرساختی است.

"Presentation"

شامل "ASP.NET Core Web API" و "Endpoint"های مربوط به "API" است.

مستندات

مستندات و فایل‌های مرتبط با پروژه در پوشه "Documents" قرار دارند.

وضعیت پروژه

"Voltra" یک پروژه در حال توسعه است و ساختار آن به‌گونه‌ای طراحی شده که امکان اضافه شدن قابلیت‌ها و بخش‌های جدید در طول توسعه وجود داشته باشد.
