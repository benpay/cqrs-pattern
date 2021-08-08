using CoreProject.Domain.Models;
using CoreProject.Domain.Repository;
using CoreProject.Handlers;
using CoreProject.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Xunit;
using static CoreProject.Commands.DeleteUserCommandClass;
using static CoreProject.Commands.InsertUserCommandClass;
using static CoreProject.Commands.UpdateUserCommandClass;

namespace CoreProjectTests
{
    public class HandlersUnitTest
    {

        [Fact]
        public void GetUserListHandlerGetAllOnceTimes()
        {
            // arrange
            var users = new List<UserModel>()
            {
                new UserModel()
                {
                    Id = Guid.NewGuid(),
                }
            };
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.All()).Returns(users);
            var getUserListHandler = new GetUserListHandler(mockUserRepository.Object);
            Mock<GetUsersListQuery> request = new Mock<GetUsersListQuery>();

            // act
            getUserListHandler.Handle(request.Object, new CancellationToken());

            // aasert
            mockUserRepository.Verify(x => x.All(), Times.Once());
        }

        [Fact]
        public void GetUserByIdHandlerOnceTimes()
        {
            var user = new UserModel() { 
                    Id = Guid.NewGuid()
            };
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(user);
            var getUserByIdHandler = new GetUserByIdHandler(mockUserRepository.Object);
            var request = new Mock<GetUserByIdQuery>(It.IsAny<Guid>());

            // act
            var result = getUserByIdHandler.Handle(request.Object, new CancellationToken());

            // aasert
            Assert.Equal(user.Id, result.Result.Id);
        }

        //[Fact]
        //public void DeleteUserHandlerOnceTimes()
        //{
        //    var user = new UserModel()
        //    {
        //        Id = Guid.NewGuid()
        //    };
        //    Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
        //    mockUserRepository.Setup(x => x.DeleteUser(It.IsAny<UserModel>())).Returns(user);
        //    var deleteUserHandler = new DeleteUserHandler(mockUserRepository.Object);
        //    var request = new Mock<DeleteUserCommand>(It.IsAny<UserModel>());

        //    // act
        //    // Use this way to solve the ambiguous match exception by refelction
        //    Type ThisDeleteUserHandler = typeof(DeleteUserHandler);
        //    MethodInfo ThisHandle = ThisDeleteUserHandler.GetMethod("Handle", new Type[] { typeof(DeleteUserCommand) });
        //    var result = ThisHandle.Invoke(null, new Object[] { request.Object, new CancellationToken() });

        //    // aasert
        //    Assert.Equal(user.Id, result.Result.Id);
        //}
    }
}
