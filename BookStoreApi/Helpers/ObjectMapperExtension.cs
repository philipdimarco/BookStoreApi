using BookStoreApi.Entities;
using BookStoreApi.Models;
using BookStoreApi.Services;
using System.Runtime.CompilerServices;

namespace BookStoreApi.Helpers
{
    public static class ObjectMapperExtension
    {
        public static BookDto FromBookEntity(this Book bookEntity)
        {
            return new BookDto()
            {
                Id = bookEntity.Id,
                Title = bookEntity.Title,
                Description = bookEntity.Description,
                Price = bookEntity.Price,
                AuthorId = bookEntity.AuthorId
            };
        }
        public static Book FromBookDto(this BookDto bookDto)
        {
            return new Book()
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Description = bookDto.Description,
                Price = bookDto.Price,
                AuthorId = bookDto.AuthorId
            };
        }

        public static Book FromCreateBookDto(this BookCreateDto bookDto)
        {
            return new Book()
            {
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Description = bookDto.Description,
                Price = bookDto.Price,
                AuthorId = bookDto.AuthorId
            };
        }

        public static UserDto FromUserEntity(this User userEntity)
        {
            return new UserDto()
            {
                Username = userEntity.Username
            };
        }

        public static User FromUserDto(this UserDto userDto, AuthUtils authUtils)
        {
            authUtils.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User()
            {
                Id = Guid.NewGuid(),
                Username = userDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        public static Book MapFromBookDto(this BookDto fromBookDto, Book toBookEntity)
        {
            if (!String.IsNullOrEmpty(fromBookDto.Title))
            {
                toBookEntity.Title = fromBookDto.Title;
            }
            if (!String.IsNullOrEmpty(fromBookDto.Description))
            {
                toBookEntity.Description = fromBookDto.Description;
            }
            if (fromBookDto.Price > 00.00M)
            {
                toBookEntity.Price = fromBookDto.Price;
            }
            if (fromBookDto.AuthorId != Guid.Empty)
            {
                toBookEntity.AuthorId = fromBookDto.AuthorId;
            }
            return toBookEntity;
        }

    }
}
