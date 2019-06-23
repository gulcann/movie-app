CREATE TABLE [dbo].[movie](
	[Title] [varchar](max) NULL,
	[Year] [char](10) NULL,
	[Rated] [char](10) NULL,
	[Released] [varchar](50) NULL,
	[Runtime] [varchar](50) NULL,
	[Genre] [varchar](max) NULL,
	[Director] [varchar](50) NULL,
	[Writer] [varchar](max) NULL,
	[Actors] [varchar](max) NULL,
	[Plot] [varchar](max) NULL,
	[Language] [varchar](50) NULL,
	[Country] [varchar](max) NULL,
	[Awards] [varchar](max) NULL,
	[Poster] [varchar](max) NULL,
	[Metascore] [varchar](50) NULL,
	[ImdbRating] [char](10) NULL,
	[ImdbVotes] [varchar](50) NULL,
	[Imdbid] [char](10) NOT NULL,
	[Type] [varchar](50) NULL,
	[Dvd] [varchar](50) NULL,
	[BoxOffice] [varchar](50) NULL,
	[Production] [varchar](max) NULL,
	[Website] [varchar](max) NULL,
	[Response] [char](10) NULL,
	[RecordDate] [datetime] NULL,
 CONSTRAINT [PK_movie] PRIMARY KEY CLUSTERED 
(
	[Imdbid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[rating](
	[Imdbid] [varchar](50) NULL,
	[Source] [varchar](max) NULL,
	[Value] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]