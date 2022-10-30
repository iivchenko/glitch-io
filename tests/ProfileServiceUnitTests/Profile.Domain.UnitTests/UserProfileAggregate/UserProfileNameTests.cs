using Profile.Domain.UserProfileAggregate;

namespace Profile.Domain.UnitTests.UserProfileAggregate;

public sealed class UserProfileNameTests
{
    private const string TheName = "Rorck";

    [Fact]
    public void Create_ValidName_Succeed()
    {
        // Act
        var result = UserProfileName.Create(TheName);

        // Assert
        result.Value.Should().Be(TheName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_Emptyname_Throws(string name)
    {
        // Act
        Action sut = () => UserProfileName.Create(name);

        // Assert
        sut.Should()
            .Throw<UserProfileException>()
            .WithMessage("User Profile Name can't be empty or blank!");
    }

    [Fact]
    public void Create_NameToLong_Throws()
    {
        // Arrange
        var name = new String('1', 26);

        // Act
        Action sut = () => UserProfileName.Create(name);

        sut.Should()
            .Throw<UserProfileException>()
            .WithMessage($"User Profile Name shoule not exceed {UserProfileConstraints.NameMaxLength} symbols!");
    }

    [Fact]
    public void Implicit_NameToString_Succeded()
    {
        // Arrange
        var name = UserProfileName.Create(TheName);

        // Act 
        string result = name;

        // Assert
        result.Should().Be(TheName);     
    }

    [Fact]
    public void Explicit_ValidName_Succeed()
    {
        // Act
        var result = (UserProfileName)TheName;

        // Assert
        result.Value.Should().Be(TheName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Explicit_Emptyname_Throws(string name)
    {
        // Act
        Action sut = () =>
        {
            var _ = (UserProfileName)name;
        };

        // Assert
        sut.Should()
            .Throw<UserProfileException>()
            .WithMessage("User Profile Name can't be empty or blank!");
    }

    [Fact]
    public void Explicit_NameToLong_Throws()
    {
        // Arrange
        var name = new String('1', 26);

        // Act
        Action sut = () =>
        {
            var _ = (UserProfileName)name;
        };

        sut.Should()
            .Throw<UserProfileException>()
            .WithMessage($"User Profile Name shoule not exceed {UserProfileConstraints.NameMaxLength} symbols!");
    }

    [Fact]
    public void ToString_NameToString_Succeded()
    {
        // Arrange
        var name = UserProfileName.Create(TheName);

        // Act 
        var result = name.ToString();

        // Assert
        result.Should().Be(TheName);
    }
}
