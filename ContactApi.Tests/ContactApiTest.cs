using Xunit;
using ContactApi.Controllers;
using Moq;
using ContactApi.Models;
using ContactApi.Services;

namespace ContactApi.Tests;

public class ContactApiTest
{
    [Fact]
    public void GetAllContactCardsApi()
    {
        
        var contactCardServiceMock = new Mock<IContactCardService>();
        contactCardServiceMock.Setup(p => p.GetAllContactCards())
            .Returns(new List<ContactCard>()
            {
                new ContactCard(Guid.NewGuid().ToString(), "Carlos Lopez", "1136 S Boot Ln, West Grove PA"),
                new ContactCard(Guid.NewGuid().ToString(), "John Doe", "1 Pennsylvania Av, Washington DC" ),
                new ContactCard(Guid.NewGuid().ToString(), "Sam Smith", "13 Evergreen St, Springfield MA")
            });

        var contactCardController = new ContactCardController(contactCardServiceMock.Object);

        var resultGetContactCards = contactCardController.Get();
        Assert.NotNull(resultGetContactCards);
        Assert.Equal(3, resultGetContactCards.Count());
    }
    
    [Fact]
    public void GetContactCardApi()
    {
        ContactCard sample = new ContactCard("4c5a9082-c03a-4d0c-a2d1-973d34c8c567", "John Doe",
            "1 Pennsylvania Av, Washington DC");
        var contactCardServiceMock = new Mock<IContactCardService>();
        contactCardServiceMock.Setup(p => p.GetContactCard("4c5a9082-c03a-4d0c-a2d1-973d34c8c567"))
            .Returns(sample);

        var contactCardController = new ContactCardController(contactCardServiceMock.Object);

        var resultGetContactCard = contactCardController.Get("4c5a9082-c03a-4d0c-a2d1-973d34c8c567");
        Assert.NotNull(resultGetContactCard);
        Assert.Equal(sample, resultGetContactCard);
    }
    
    
}