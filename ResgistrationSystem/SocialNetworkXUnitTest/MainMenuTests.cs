using SocialNetwork.Core;
using SocialNetwork;
using System;
using Xunit;
using Moq;
using Autofac.Extras.Moq;

namespace SocialNetworkXUnitTest
{
    public class MainMenuTests
    {
        [Fact]
        public void Test1()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // arrange 
                mock.Mock<IUserMenegment>()
                    .Setup(e => e.RegisterUser(It.IsAny<IRegisterModel>()));

                // act
                var cls = mock.Create<MainMenu>();
                cls.Register(3);

                // assert
               mock.Mock<IUserMenegment>()
                    .Verify(e => e.RegisterUser(It.IsAny<IRegisterModel>()), Times.Exactly(0));
            }

            /*
            // arrange 
            var userMenegment = new Mock<IUserMenegment>();
            userMenegment.Setup(e => e.RegisterUser(It.IsAny<IRegisterModel>()));
   
            var menu = new MainMenu();
            // act
            menu.Register(params correct);
            // assert
            //userMenegment.Verify(e => e.RegisterUser(It.IsAny<IRegisterModel>()));
            userMenegment.Verify(e => e.RegisterUser(It.Is<IRegisterModel>(e => e == new RegisterModel()))); // enum-ic berel
            */
        }

    }
}
