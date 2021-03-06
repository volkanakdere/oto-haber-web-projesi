USE [master]
GO
/****** Object:  Database [otohaber]    Script Date: 3.06.2021 22:52:49 ******/
CREATE DATABASE [otohaber]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'otohaber', FILENAME = N'C:\Users\Yaxu\otohaber.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'otohaber_log', FILENAME = N'C:\Users\Yaxu\otohaber_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [otohaber] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [otohaber].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [otohaber] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [otohaber] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [otohaber] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [otohaber] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [otohaber] SET ARITHABORT OFF 
GO
ALTER DATABASE [otohaber] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [otohaber] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [otohaber] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [otohaber] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [otohaber] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [otohaber] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [otohaber] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [otohaber] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [otohaber] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [otohaber] SET  DISABLE_BROKER 
GO
ALTER DATABASE [otohaber] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [otohaber] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [otohaber] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [otohaber] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [otohaber] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [otohaber] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [otohaber] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [otohaber] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [otohaber] SET  MULTI_USER 
GO
ALTER DATABASE [otohaber] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [otohaber] SET DB_CHAINING OFF 
GO
ALTER DATABASE [otohaber] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [otohaber] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [otohaber] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [otohaber] SET QUERY_STORE = OFF
GO
USE [otohaber]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [otohaber]
GO
/****** Object:  Table [dbo].[Haberler]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Haberler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KategoriId] [int] NOT NULL,
	[Baslik] [nvarchar](100) NOT NULL,
	[HaberOzeti] [nvarchar](300) NOT NULL,
	[Icerik] [nvarchar](max) NOT NULL,
	[Tarih] [datetime] NOT NULL,
	[YazarId] [int] NOT NULL,
	[OkunmaSayisi] [int] NOT NULL,
 CONSTRAINT [PK_Haberler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HaberResimler]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HaberResimler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResimDosyaYolu] [nvarchar](255) NOT NULL,
	[HaberId] [int] NOT NULL,
 CONSTRAINT [PK_HaberResimler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Soyadi] [nvarchar](50) NOT NULL,
	[Eposta] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[RolId] [int] NOT NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roller]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RolAdi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yazarlar]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yazarlar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[YazarAdi] [nvarchar](50) NOT NULL,
	[YazarSoyadi] [nvarchar](50) NOT NULL,
	[Eposta] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Yazarlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yorumlar]    Script Date: 3.06.2021 22:52:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yorumlar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HaberId] [int] NOT NULL,
	[KullaniciId] [int] NOT NULL,
	[YorumMetni] [nvarchar](500) NOT NULL,
	[OnaylandiMi] [bit] NOT NULL,
	[YorumTarihi] [datetime] NOT NULL,
 CONSTRAINT [PK_Yorumlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Haberler] ON 

INSERT [dbo].[Haberler] ([Id], [KategoriId], [Baslik], [HaberOzeti], [Icerik], [Tarih], [YazarId], [OkunmaSayisi]) VALUES (5, 1002, N'30 May??s T??rkiye''nin koronavir??s tablosu', N'Sa??l??k Bakanl?????? g??n??n koronavir??s verilerini payla??t??.VAKA SAYISI 7 B??N??N ALTINDA
Bakanl??????n payla??t?????? tabloya g??re bug??n yap??lan testler sonucu 6 bin 933 yeni vaka espit edildi.Vakalar aras??nda ise 582 semptomlu hasta belirlendi.', N'<p>Koronovir&uuml;se kar???? en etkili a????y?? geli??tirerek d&uuml;nyan??n en &ouml;nemli bilim insanlar?? aras??na g&ouml;ren Alman BioNTech firmas??n??n kurucusu Prof. Dr. U??ur ??ahin ve e??i Dr. &Ouml;zlem T&uuml;reci, ??imdiye kadar 2 milyar doz a???? &uuml;retti.</p>

<p>Ancak ba??ar??lar??yla Almanya&#39;n??n en b&uuml;y&uuml;k ni??an??na lay??k g&ouml;r&uuml;len &ccedil;ift ile 200 &ccedil;al????an??, 1,5 y??l sonra a???? olabildi.</p>

<p>56 ya????ndaki U??ur ??ahin, kendisi ve e??inin ge&ccedil; a????lanmas??n??n nedenini anlatt??.</p>

<p>&ldquo;&Uuml;RETT??????M??Z A??IYI KEND??M??ZE YAPMAMIZA ??Z??N VER??LMED??&rdquo;</p>

<p>??ahin,<em><strong>&nbsp;&ldquo;&Ccedil;al????t??????m??z &uuml;lkenin kanunlar?? ve ??irketin d&uuml;zenlemeleri gere??i, &uuml;retti??imiz a????y?? kendimize yapmam??za bu zamana kadar izin verilmedi. A????n??n &ouml;ncelik listesinin d??????na &ccedil;??k??lmas??na kesinlikle m&uuml;saade edilmiyor.&rdquo;&nbsp;</strong></em>dedi.</p>

<p>&ldquo;R??SKE G??RMES?? YASAK&rdquo;</p>

<p><em><strong>&ldquo;??irketin &uuml;st kademelerinde yer alanlar ile klinikte &ccedil;al????anlar??n, yeni varyantlar??n &ccedil;??kt?????? bu s&uuml;re&ccedil;te riske girmesi yasak&rdquo;&nbsp;</strong></em>diyen Prof. Dr. ??ahin, ??&ouml;yle devam etti:</p>

<p><strong><em>&ldquo;Amac??m??z 2021&rsquo;de 1,3 milyar doz &uuml;retmek. Bu da ancak 7/24 kesintisiz &ccedil;al????ma ile m&uuml;mk&uuml;n. Ekip &uuml;yelerimizi koronavir&uuml;sten koruyabilece??imizden emin olmal??y??z. Kanunen ??irket &ccedil;al????anlar??n?? klinik denemelere bile dahil etmek m&uuml;mk&uuml;n de??il.&rdquo;</em></strong></p>
', CAST(N'2021-05-29T21:08:05.000' AS DateTime), 2, 0)
INSERT [dbo].[Haberler] ([Id], [KategoriId], [Baslik], [HaberOzeti], [Icerik], [Tarih], [YazarId], [OkunmaSayisi]) VALUES (7, 2, N'Lorem Ipsum 2', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vel leo ullamcorper, lacinia quam sit amet, vehicula lacus. Duis dignissim dolor magna, at convallis lorem varius sit amet. ', N'<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vel leo ullamcorper, lacinia quam sit amet, vehicula lacus. Duis dignissim dolor magna, at convallis lorem varius sit amet. Nam sollicitudin felis quis ipsum feugiat varius. Donec vestibulum orci vitae ex lacinia mollis. Fusce bibendum sem vel tortor rutrum, a hendrerit diam sagittis. Nullam ante velit, placerat vel mauris eu, tincidunt tristique ex. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque quis tempor lorem, eget aliquam diam. Ut eget tellus porta purus elementum congue sed eu quam. Mauris eget nunc elit. Sed quam lacus, volutpat a tempus nec, mollis ac sapien. Vestibulum dui justo, vulputate vel nisl non, maximus vestibulum erat. Nam vitae arcu sem. Nunc eu libero viverra, varius eros vitae, consectetur sapien. Vivamus eu cursus lectus. In nec convallis leo.</p>

<p>Phasellus eleifend interdum dolor, id dictum leo varius a. Vestibulum vulputate condimentum varius. Vestibulum et elementum orci. Morbi accumsan nec ante id bibendum. Pellentesque congue venenatis facilisis. Cras ultricies, mi quis dictum tristique, libero felis suscipit dolor, tristique tristique felis arcu nec enim. Duis rhoncus est at rutrum sollicitudin. Cras mi magna, tempor nec tellus et, vulputate rutrum leo. Curabitur tincidunt pulvinar dapibus. Donec ligula tellus, eleifend vel ipsum at, vulputate rutrum tellus. Vivamus sagittis purus eget fringilla faucibus.</p>

<p>Suspendisse ultricies et justo vel consectetur. Vivamus rutrum nunc elementum velit facilisis, eget tincidunt nibh lacinia. Suspendisse venenatis maximus nulla nec auctor. Morbi in ex a metus sollicitudin ullamcorper. Morbi nisi arcu, blandit et pulvinar sit amet, pellentesque a ante. Quisque ultrices lectus mauris, non semper ante fermentum non. Phasellus vel fringilla justo. Sed malesuada scelerisque est vestibulum egestas. Praesent ornare, nunc eu porta ullamcorper, mi mi tincidunt tellus, et ullamcorper sapien arcu sed elit. Donec diam tellus, varius a hendrerit sit amet, accumsan nec mi. Duis consequat erat eu dolor volutpat maximus. Sed placerat consequat est, at viverra eros pulvinar dignissim.</p>

<p>Proin dignissim tortor vitae risus luctus, ac vehicula leo pulvinar. Aliquam semper suscipit neque. Nam pellentesque ultrices aliquet. Ut in ipsum arcu. Duis auctor euismod mi ut auctor. In maximus fringilla enim in malesuada. In convallis elementum lobortis. Ut malesuada nisl lacus, vel semper lorem blandit id. Sed dui nisi, rutrum eu leo eu, tristique malesuada urna.</p>

<p>Mauris maximus metus sed leo gravida, nec congue metus vehicula. Integer rutrum tincidunt tincidunt. Curabitur tincidunt, massa vitae aliquam tincidunt, arcu enim laoreet elit, vitae congue ligula eros finibus sapien. Quisque id lacinia dui. Nulla facilisi. Etiam pellentesque feugiat massa. Aenean ultrices blandit ex, eu blandit eros faucibus quis. Nulla rutrum nec ex eget porttitor. Interdum et malesuada fames ac ante ipsum primis in faucibus. In sollicitudin lorem eget ornare molestie. Phasellus accumsan purus nulla. In commodo, arcu ac bibendum rhoncus, lacus ex cursus arcu, eu varius arcu sem nec diam. Aliquam id sodales erat, quis lobortis urna. In ante eros, rhoncus pharetra laoreet sit amet, varius sit amet tellus. Aenean dignissim sagittis nunc condimentum accumsan.</p>
', CAST(N'2021-05-29T21:26:53.317' AS DateTime), 2, 0)
SET IDENTITY_INSERT [dbo].[Haberler] OFF
GO
SET IDENTITY_INSERT [dbo].[HaberResimler] ON 

INSERT [dbo].[HaberResimler] ([Id], [ResimDosyaYolu], [HaberId]) VALUES (1, N't52ueofm-vmo.jpg', 5)
INSERT [dbo].[HaberResimler] ([Id], [ResimDosyaYolu], [HaberId]) VALUES (2, N'2zcrqucz-zfq.jpg', 7)
SET IDENTITY_INSERT [dbo].[HaberResimler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi]) VALUES (2, N'Elektrikli Ara??lar')
INSERT [dbo].[Kategoriler] ([Id], [KategoriAdi]) VALUES (1002, N'Sa??l??k')
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([Id], [Adi], [Soyadi], [Eposta], [Sifre], [RolId]) VALUES (1, N'Volkan', N'Akdere', N'volkanakdere@gmail.com', N'admin123', 1)
INSERT [dbo].[Kullanicilar] ([Id], [Adi], [Soyadi], [Eposta], [Sifre], [RolId]) VALUES (2, N'Yasin', N'Aksu', N'yasinaksu@gmail.com', N'admin123', 2)
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Roller] ON 

INSERT [dbo].[Roller] ([Id], [RolAdi]) VALUES (1, N'Admin')
INSERT [dbo].[Roller] ([Id], [RolAdi]) VALUES (2, N'??ye')
SET IDENTITY_INSERT [dbo].[Roller] OFF
GO
SET IDENTITY_INSERT [dbo].[Yazarlar] ON 

INSERT [dbo].[Yazarlar] ([Id], [YazarAdi], [YazarSoyadi], [Eposta]) VALUES (1, N'Re??at Nuri', N'G??ntekin', N'resatnuriguntekin@gmail.com')
INSERT [dbo].[Yazarlar] ([Id], [YazarAdi], [YazarSoyadi], [Eposta]) VALUES (2, N'Peyami', N'Safa', N'peyamisafa@gmail.com')
SET IDENTITY_INSERT [dbo].[Yazarlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Yorumlar] ON 

INSERT [dbo].[Yorumlar] ([Id], [HaberId], [KullaniciId], [YorumMetni], [OnaylandiMi], [YorumTarihi]) VALUES (4, 5, 1, N'Yorum metnidir', 1, CAST(N'2021-05-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Yorumlar] ([Id], [HaberId], [KullaniciId], [YorumMetni], [OnaylandiMi], [YorumTarihi]) VALUES (7, 5, 2, N'k??f??rl?? i??erik', 0, CAST(N'2021-05-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Yorumlar] ([Id], [HaberId], [KullaniciId], [YorumMetni], [OnaylandiMi], [YorumTarihi]) VALUES (1002, 7, 2, N'Bir yorum da benden gelsin.', 1, CAST(N'2021-06-03T22:44:38.780' AS DateTime))
SET IDENTITY_INSERT [dbo].[Yorumlar] OFF
GO
ALTER TABLE [dbo].[Haberler]  WITH CHECK ADD  CONSTRAINT [FK_Haberler_Kategoriler] FOREIGN KEY([KategoriId])
REFERENCES [dbo].[Kategoriler] ([Id])
GO
ALTER TABLE [dbo].[Haberler] CHECK CONSTRAINT [FK_Haberler_Kategoriler]
GO
ALTER TABLE [dbo].[Haberler]  WITH CHECK ADD  CONSTRAINT [FK_Haberler_Yazarlar] FOREIGN KEY([YazarId])
REFERENCES [dbo].[Yazarlar] ([Id])
GO
ALTER TABLE [dbo].[Haberler] CHECK CONSTRAINT [FK_Haberler_Yazarlar]
GO
ALTER TABLE [dbo].[HaberResimler]  WITH CHECK ADD  CONSTRAINT [FK_HaberResimler_Haberler] FOREIGN KEY([HaberId])
REFERENCES [dbo].[Haberler] ([Id])
GO
ALTER TABLE [dbo].[HaberResimler] CHECK CONSTRAINT [FK_HaberResimler_Haberler]
GO
ALTER TABLE [dbo].[Kullanicilar]  WITH CHECK ADD  CONSTRAINT [FK_Kullanicilar_Roller] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roller] ([Id])
GO
ALTER TABLE [dbo].[Kullanicilar] CHECK CONSTRAINT [FK_Kullanicilar_Roller]
GO
ALTER TABLE [dbo].[Yorumlar]  WITH CHECK ADD  CONSTRAINT [FK_Yorumlar_Haberler] FOREIGN KEY([HaberId])
REFERENCES [dbo].[Haberler] ([Id])
GO
ALTER TABLE [dbo].[Yorumlar] CHECK CONSTRAINT [FK_Yorumlar_Haberler]
GO
ALTER TABLE [dbo].[Yorumlar]  WITH CHECK ADD  CONSTRAINT [FK_Yorumlar_Kullanicilar] FOREIGN KEY([KullaniciId])
REFERENCES [dbo].[Kullanicilar] ([Id])
GO
ALTER TABLE [dbo].[Yorumlar] CHECK CONSTRAINT [FK_Yorumlar_Kullanicilar]
GO
USE [master]
GO
ALTER DATABASE [otohaber] SET  READ_WRITE 
GO
