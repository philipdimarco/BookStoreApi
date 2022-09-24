﻿using BookStoreApi.Entities;
using BookStoreApi.Models;
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
                Username = userDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }


    }
}