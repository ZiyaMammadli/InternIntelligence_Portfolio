# Portfolio API

## Description

This project is a Portfolio Management API developed using **ASP.NET Core Web API (.NET 8)**. The API is designed to manage dynamic portfolio content, including projects, skills, achievements, and contact form submissions.

## Features

- CRUD operations for Projects, Skills, and Achievements
- Contact Form submission handling
- JWT Authentication for secure access to management endpoints
- Input validation with FluentValidation
- Rate Limiting to prevent brute-force attacks
- HTTPS enforced in Production environment
- Integration with frontend applications via CORS

## Technologies Used

- **ASP.NET Core 8**
- **Entity Framework Core**
- **JWT Authentication**
- **FluentValidation**
- **MediatR**
- **Swagger (OpenAPI)**
- **Rate Limiting**

## Installation

1. Clone the repository:

```bash
git clone https://github.com/ZiyaMammadli/InternIntelligence_Portfolio.git
cd InternIntelligence_Portfolio
```

2. Configure the **appsettings.json** with your database connection string.
3. Apply Migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. Run the project:

```bash
dotnet run
```

## API Endpoints

### Authentication
| Endpoint        | Method | Description  | Authentication |
| -------------- | ------ | ------------ | -------------- |
| /api/Auth/Register | POST   | User Register   | ❌              |
| /api/Auth/Login | POST   | User Login   | ❌              |
| /api/Auth/Revoke | POST   | User Revoke   | ❌              |
| /api/Auth/RefreshToken | POST   | User RefreshToken   | ❌              |

### Projects
| Endpoint           | Method | Description         | Authentication |
| ------------------ | ------ | ------------------- | -------------- |
| /api/Project/GetAllProjects      | GET    | Get all Projects    | ✅              |
| /api/Project/Create      | POST   | Create Project      | ✅              |
| /api/Project/Update | PUT    | Update Project      | ✅              |
| /api/Project/Delete | DELETE | Delete Project      | ✅              |

### Skills
| Endpoint       | Method | Description      | Authentication |
| -------------- | ------ | ---------------- | -------------- |
| /api/Skill/GetAllSkills    | GET    | Get all Skills   | ✅              |
| /api/Skill/Create    | POST   | Create Skill     | ✅              |
| /api/Skill/Update | PUT  | Update Skill     | ✅              |
| /api/Skill/Delete | DELETE | Delete Skill   | ✅              |

### Achievements
| Endpoint           | Method | Description            | Authentication |
| ------------------ | ------ | ---------------------- | -------------- |
| /api/Achievement/GetAllAchievements  | GET    | Get all Achievements   | ✅              |
| /api/Achievement/Create  | POST   | Create Achievement     | ✅              |
| /api/Achievement/Update | PUT  | Update Achievement   | ✅              |
| /api/Achievement/Delete | DELETE | Delete Achievement | ✅              |

### Contact Form
| Endpoint      | Method | Description             | Authentication |
| ------------- | ------ | ----------------------- | -------------- |
| /api/ContactForm/SubmitForm  | POST   | Submit Form             | ❌             |
| /api/ContactForm/GetAllContactForms  | GET   | Get all Contact Forms             | ❌             |

✅ - Requires JWT Token ❌ - Public Access

## Security

- **JWT Token**: Secure API endpoints
- **Input Validation**: All incoming requests are validated using FluentValidation.
- **Rate Limiting**: Limits the number of requests per minute to prevent brute-force attacks.
- **HTTPS**: Enforced in production mode.

## Usage

To authenticate and access protected endpoints:

1. Obtain JWT token from `/api/auth/login`.
2. Include the token in the **Authorization** header as:

```bash
Authorization: Bearer {your_token}
```

## Contact

For questions or issues, please reach out to:

- Email: [ziyam040@gmail.com](mailto:ziyam040@gmail.com)
- GitHub: [Your GitHub Profile](https://github.com/ZiyaMammadli)

## License

This project is licensed under the MIT License.

