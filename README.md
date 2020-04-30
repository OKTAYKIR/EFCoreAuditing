# EFCoreAuditing
![Build Status](https://github.com/OKTAYKIR/EFCoreAuditing/workflows/CI/badge.svg)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](#contributing)
[![nuget](https://img.shields.io/nuget/v/EFCore.Auditing)](https://www.nuget.org/packages/EFCore.Auditing/)

A Library for EntityFrameworkCore to support automatically recording data changes history (audit logging), soft-delete, and Snakecase naming convention functionality.

## :package: Installation
EFCore.Auditing is available on [NuGet](https://www.nuget.org/packages/EFCore.Auditing/). 

```sh
dotnet add package EFCore.Auditing
```

## 🚀 How to use
EFCoreAuditing will recording all the data changing history in one table named 'Audit'.

###### 1. Enable Audit log with using AuditLogDbContext
 ```c#
public class UserDbContext : AuditLogDbContext<Guid>
{
    public UserDbContext(DbContextOptions<UserDbContext> dbOptions) 
        : base(dbOptions)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder
            .SnakeCaseifyNames() //Change all the table names and column names to snake_case.
            .EnableSoftDelete(); //Enable soft-delete functionality.
    }
}
```

## 🤝 Contributing
1. Fork it ( https://github.com/OKTAYKIR/EFCoreAuditing/fork )
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create a new Pull Request  

## Show your support
Please ⭐️ this repository if this project helped you!

## 📝 License
MIT License
