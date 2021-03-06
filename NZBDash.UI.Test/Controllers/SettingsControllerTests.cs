﻿using System.Web.Mvc;
using System.Web.UI.WebControls;

using Moq;

using NUnit.Framework;

using NZBDash.Core.Interfaces;
using NZBDash.Core.Model.Settings;
using NZBDash.UI.Controllers;
using NZBDash.UI.Models.Settings;

using TestStack.FluentMVCTesting;

namespace NZBDash.UI.Test.Controllers
{
    [TestFixture]
    public class SettingsControllerTests
    {
        private SettingsController _controller;

        [Test]
        public void GetNzbGetSettingsReturnsDefaultViewWithModel()
        {
            var expectedDto = new NzbGetSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Password = "pass", Port = 2, ShowOnDashboard = true, Username = "user" };
            var settingsMock = new Mock<ISettingsService<NzbGetSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();

            _controller = new SettingsController(settingsMock.Object, null, null, null, null);
            _controller.WithCallTo(x => x.NzbGetSettings()).ShouldRenderDefaultView();

            var result = (ViewResult)_controller.NzbGetSettings();
            var model = (NzbGetSettingsViewModel)result.Model;

            Assert.That(model.Enabled, Is.EqualTo(expectedDto.Enabled));
            Assert.That(model.Id, Is.EqualTo(expectedDto.Id));
            Assert.That(model.IpAddress, Is.EqualTo(expectedDto.IpAddress));
            Assert.That(model.Password, Is.EqualTo(expectedDto.Password));
            Assert.That(model.Port, Is.EqualTo(expectedDto.Port));
            Assert.That(model.ShowOnDashboard, Is.EqualTo(expectedDto.ShowOnDashboard));
            Assert.That(model.Username, Is.EqualTo(expectedDto.Username));
        }


        [Test]
        public void SettingsReturnsDefaultIndex()
        {
            _controller = new SettingsController(null, null, null, null, null);
            _controller.WithModelErrors().WithCallTo(x => x.Index()).ShouldRenderDefaultView();
        }

        [Test]
        public void PostNzbGetSettingsReturnsErrorWithBadModel()
        {
            var expectedDto = new NzbGetSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Password = "pass", Port = 2, ShowOnDashboard = true, Username = "user" };
            var settingsMock = new Mock<ISettingsService<NzbGetSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<NzbGetSettingsDto>())).Returns(true).Verifiable();

            _controller = new SettingsController(settingsMock.Object, null, null, null, null);
            var model = new NzbGetSettingsViewModel();
            _controller.WithModelErrors().WithCallTo(x => x.NzbGetSettings(model)).ShouldRenderDefaultView().WithModel(model);
        }

        [Test]
        public void PostNzbGetSettingsReturnsDefaultView()
        {
            var expectedDto = new NzbGetSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Password = "pass", Port = 2, ShowOnDashboard = true, Username = "user" };
            var settingsMock = new Mock<ISettingsService<NzbGetSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<NzbGetSettingsDto>())).Returns(true).Verifiable();

            _controller = new SettingsController(settingsMock.Object, null, null, null, null);

            var model = new NzbGetSettingsViewModel();
            _controller.WithCallTo(x => x.NzbGetSettings(model)).ShouldRedirectTo(c => c.NzbGetSettings);
        }

        [Test]
        public void PostNzbGetSettingsCouldNotSaveToDb()
        {
            var expectedDto = new NzbGetSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Password = "pass", Port = 2, ShowOnDashboard = true, Username = "user" };
            var settingsMock = new Mock<ISettingsService<NzbGetSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<NzbGetSettingsDto>())).Returns(false).Verifiable();

            _controller = new SettingsController(settingsMock.Object, null, null, null, null);

            var model = new NzbGetSettingsViewModel();
            _controller.WithCallTo(x => x.NzbGetSettings(model)).ShouldRenderView("Error");
        }

        [Test]
        public void GetSonarrSettingsReturnsDefaultView()
        {
            var expectedDto = new SonarrSettingsViewModelDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SonarrSettingsViewModelDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();

            _controller = new SettingsController(null, null, settingsMock.Object, null, null);
            _controller.WithCallTo(x => x.SonarrSettings()).ShouldRenderDefaultView();

            var result = (ViewResult)_controller.SonarrSettings();
            var model = (SonarrSettingsViewModel)result.Model;

            Assert.That(model.Enabled, Is.EqualTo(expectedDto.Enabled));
            Assert.That(model.Id, Is.EqualTo(expectedDto.Id));
            Assert.That(model.IpAddress, Is.EqualTo(expectedDto.IpAddress));
            Assert.That(model.ApiKey, Is.EqualTo(expectedDto.ApiKey));
            Assert.That(model.Port, Is.EqualTo(expectedDto.Port));
            Assert.That(model.ShowOnDashboard, Is.EqualTo(expectedDto.ShowOnDashboard));
        }

        [Test]
        public void PostSonarrSettingsReturnsErrorWithBadModel()
        {
            var expectedDto = new SonarrSettingsViewModelDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SonarrSettingsViewModelDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<SonarrSettingsViewModelDto>())).Returns(true).Verifiable();

            _controller = new SettingsController(null, null, settingsMock.Object, null, null);

            var model = new SonarrSettingsViewModel();
            _controller.WithModelErrors().WithCallTo(x => x.SonarrSettings(model)).ShouldRenderDefaultView().WithModel(model);
        }

        [Test]
        public void PostSonarrSettingsReturnsDefaultView()
        {
            var expectedDto = new SonarrSettingsViewModelDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SonarrSettingsViewModelDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<SonarrSettingsViewModelDto>())).Returns(true).Verifiable();

            _controller = new SettingsController(null, null, settingsMock.Object, null, null);

            var model = new SonarrSettingsViewModel();
            _controller.WithCallTo(x => x.SonarrSettings(model)).ShouldRedirectTo(c => c.SonarrSettings);
        }

        [Test]
        public void PostSonarrSettingsCouldNotSaveToDb()
        {
            var expectedDto = new SonarrSettingsViewModelDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SonarrSettingsViewModelDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<SonarrSettingsViewModelDto>())).Returns(false).Verifiable();

            _controller = new SettingsController(null, null, settingsMock.Object, null, null);

            var model = new SonarrSettingsViewModel();
            _controller.WithCallTo(x => x.SonarrSettings(model)).ShouldRenderView("Error");
        }

        [Test]
        public void GetSabNzbdSettings()
        {
            var expectedDto = new SabNzbdSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SabNzbdSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();

            _controller = new SettingsController(null, settingsMock.Object, null, null, null);
            _controller.WithCallTo(x => x.SabNzbSettings()).ShouldRenderDefaultView();

            var result = (ViewResult)_controller.SabNzbSettings();
            var model = (SabNzbSettingsViewModel)result.Model;

            Assert.That(model.Enabled, Is.EqualTo(expectedDto.Enabled));
            Assert.That(model.Id, Is.EqualTo(expectedDto.Id));
            Assert.That(model.IpAddress, Is.EqualTo(expectedDto.IpAddress));
            Assert.That(model.ApiKey, Is.EqualTo(expectedDto.ApiKey));
            Assert.That(model.Port, Is.EqualTo(expectedDto.Port));
            Assert.That(model.ShowOnDashboard, Is.EqualTo(expectedDto.ShowOnDashboard));
        }

        [Test]
        public void PostSabNzbdSettingsReturnsDefaultView()
        {
            var expectedDto = new SabNzbdSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SabNzbdSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<SabNzbdSettingsDto>())).Returns(true);

            _controller = new SettingsController(null, settingsMock.Object, null, null, null);

            var model = new SabNzbSettingsViewModel();
            _controller.WithCallTo(x => x.SabNzbSettings(model)).ShouldRedirectTo(c => c.SabNzbSettings);
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<SabNzbdSettingsDto>()), Times.Once);
        }

        [Test]
        public void PostSabNzbdSettingsCouldNotSaveToDb()
        {
            var expectedDto = new SabNzbdSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SabNzbdSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<SabNzbdSettingsDto>())).Returns(false);

            _controller = new SettingsController(null, settingsMock.Object, null, null, null);

            var model = new SabNzbSettingsViewModel();
            _controller.WithCallTo(x => x.SabNzbSettings(model)).ShouldRenderView("Error");
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<SabNzbdSettingsDto>()), Times.Once);
        }

        [Test]
        public void PostSabNzbdSettingsBadModel()
        {
            var expectedDto = new SabNzbdSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<SabNzbdSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<SabNzbdSettingsDto>())).Returns(true);

            _controller = new SettingsController(null, settingsMock.Object, null, null, null);

            var model = new SabNzbSettingsViewModel();
            _controller.WithModelErrors().WithCallTo(x => x.SabNzbSettings(model)).ShouldRenderDefaultView().WithModel(model);
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<SabNzbdSettingsDto>()), Times.Never);
        }

        [Test]
        public void GetCouchPotatoSettings()
        {
            var expectedDto = new CouchPotatoSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true, Password = "pass", Username = "user"};
            var settingsMock = new Mock<ISettingsService<CouchPotatoSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();

            _controller = new SettingsController(null, null, null, settingsMock.Object, null);
            _controller.WithCallTo(x => x.CouchPotatoSettings()).ShouldRenderDefaultView();

            var result = (ViewResult)_controller.CouchPotatoSettings();
            var model = (CouchPotatoSettingsViewModel)result.Model;

            Assert.That(model.Enabled, Is.EqualTo(expectedDto.Enabled));
            Assert.That(model.Id, Is.EqualTo(expectedDto.Id));
            Assert.That(model.IpAddress, Is.EqualTo(expectedDto.IpAddress));
            Assert.That(model.ApiKey, Is.EqualTo(expectedDto.ApiKey));
            Assert.That(model.Port, Is.EqualTo(expectedDto.Port));
            Assert.That(model.ShowOnDashboard, Is.EqualTo(expectedDto.ShowOnDashboard));
            Assert.That(model.Username, Is.EqualTo(expectedDto.Username));
            Assert.That(model.Password, Is.EqualTo(expectedDto.Password));
        }

        [Test]
        public void PostCouchPotatoSettingsReturnsDefaultView()
        {
            var expectedDto = new CouchPotatoSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true, Password = "pass", Username = "user" };
            var settingsMock = new Mock<ISettingsService<CouchPotatoSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<CouchPotatoSettingsDto>())).Returns(true);

            _controller = new SettingsController(null, null, null, settingsMock.Object, null);

            var model = new CouchPotatoSettingsViewModel();
            _controller.WithCallTo(x => x.CouchPotatoSettings(model)).ShouldRedirectTo(c => c.CouchPotatoSettings);
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<CouchPotatoSettingsDto>()), Times.Once);
        }

        [Test]
        public void PostCouchPotatoSettingsCouldNotSaveToDb()
        {
            var expectedDto = new CouchPotatoSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<CouchPotatoSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<CouchPotatoSettingsDto>())).Returns(false);

            _controller = new SettingsController(null, null, null, settingsMock.Object, null);

            var model = new CouchPotatoSettingsViewModel();
            _controller.WithCallTo(x => x.CouchPotatoSettings(model)).ShouldRenderView("Error");
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<CouchPotatoSettingsDto>()), Times.Once);
        }

        [Test]
        public void PostCouchPotatoSettingsBadModel()
        {
            var expectedDto = new CouchPotatoSettingsDto { Enabled = true, Id = 2, IpAddress = "192", ApiKey = "pass", Port = 2, ShowOnDashboard = true };
            var settingsMock = new Mock<ISettingsService<CouchPotatoSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<CouchPotatoSettingsDto>())).Returns(true);

            _controller = new SettingsController(null, null, null, settingsMock.Object, null);

            var model = new CouchPotatoSettingsViewModel();
            _controller.WithModelErrors().WithCallTo(x => x.CouchPotatoSettings(model)).ShouldRenderDefaultView().WithModel(model);
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<CouchPotatoSettingsDto>()), Times.Never);
        }

        [Test]
        public void GetPlexSettings()
        {
            var expectedDto = new PlexSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Port = 2, ShowOnDashboard = true, Password = "pass", Username = "user" };
            var settingsMock = new Mock<ISettingsService<PlexSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto).Verifiable();

            _controller = new SettingsController(null, null, null, null, settingsMock.Object);
            _controller.WithCallTo(x => x.PlexSettings()).ShouldRenderDefaultView();

            var result = (ViewResult)_controller.PlexSettings();
            var model = (PlexSettingsViewModel)result.Model;

            Assert.That(model.Enabled, Is.EqualTo(expectedDto.Enabled));
            Assert.That(model.Id, Is.EqualTo(expectedDto.Id));
            Assert.That(model.IpAddress, Is.EqualTo(expectedDto.IpAddress));
            Assert.That(model.Port, Is.EqualTo(expectedDto.Port));
            Assert.That(model.ShowOnDashboard, Is.EqualTo(expectedDto.ShowOnDashboard));
            Assert.That(model.Username, Is.EqualTo(expectedDto.Username));
            Assert.That(model.Password, Is.EqualTo(expectedDto.Password));
        }

        [Test]
        public void PostPlexSettingsReturnsDefaultView()
        {
            var expectedDto = new PlexSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Port = 2, ShowOnDashboard = true, Password = "pass", Username = "user" };
            var settingsMock = new Mock<ISettingsService<PlexSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<PlexSettingsDto>())).Returns(true);


            _controller = new SettingsController(null, null, null, null, settingsMock.Object);

            var model = new PlexSettingsViewModel();
            _controller.WithCallTo(x => x.PlexSettings(model)).ShouldRedirectTo(c => c.PlexSettings);
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<PlexSettingsDto>()), Times.Once);
        }

        [Test]
        public void PostPlexSettingsCouldNotSaveToDb()
        {
            var expectedDto = new PlexSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Port = 2, ShowOnDashboard = true, Password = "pass", Username = "user" };
            var settingsMock = new Mock<ISettingsService<PlexSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<PlexSettingsDto>())).Returns(false);


            _controller = new SettingsController(null, null, null, null, settingsMock.Object);

            var model = new PlexSettingsViewModel();
            _controller.WithCallTo(x => x.PlexSettings(model)).ShouldRenderView("Error");
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<PlexSettingsDto>()), Times.Once);
        }

        [Test]
        public void PostPlexSettingsBadModel()
        {
            var expectedDto = new PlexSettingsDto { Enabled = true, Id = 2, IpAddress = "192", Port = 2, ShowOnDashboard = true, Password = "pass", Username = "user" };
            var settingsMock = new Mock<ISettingsService<PlexSettingsDto>>();

            settingsMock.Setup(x => x.GetSettings()).Returns(expectedDto);
            settingsMock.Setup(x => x.SaveSettings(It.IsAny<PlexSettingsDto>())).Returns(true);


            _controller = new SettingsController(null, null, null, null, settingsMock.Object);

            var model = new PlexSettingsViewModel();
            _controller.WithModelErrors().WithCallTo(x => x.PlexSettings(model)).ShouldRenderDefaultView().WithModel(model);
            settingsMock.Verify(x => x.SaveSettings(It.IsAny<PlexSettingsDto>()), Times.Never);
        }
    }
}
