Create Table Products(
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL,
	[Type] NVARCHAR(255) NULL,
	[Barcode] NVARCHAR(255) NOT NULL,
	[Price] DECIMAL(18,2) NOT NULL,
	[OpenPrice] BIT NULL,
	[ButtonColor] NVARCHAR(255) NULL,
	[TextColor] NVARCHAR(255) NULL,
	[InvoiceNumber] NVARCHAR(255) NOT NULL,
	[UpdatedBy] INT NULL,
    [CreatedBy] INT NULL,
    [DeletedBy] INT NULL,
    [CreatedDate] DATETIME2 (7) Default GETDATE(),
    [DeletedDate] DATETIME2 (7) NULL,
    [UpdatedDate] DATETIME2 (7) NULL,
    [IsDeleted] BIT NULL Default 0
);


Create Table Ingredients(
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[MinimumCount] INT NOT NULL,
	[MaximumCount] INT  NOT NULL,
	[FreeIngredientCount] INT NOT NULL,
);


Create Table Departments(
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL,
);

Create Table AllergenGroups(
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL,
	[Code] NVARCHAR(255) NOT NULL
);


Create Table ProductIngredients(
	Product_id INT,
	Ingredient_id INT,
	PRIMARY KEY(Product_id, Ingredient_id),
	FOREIGN KEY (Product_id) REFERENCES Products(ID),
	FOREIGN KEY (Ingredient_id) REFERENCES Ingredients(ID)
);

Create Table ProductDepartments(
	Product_id INT,
	Department_id INT,
	PRIMARY KEY(Product_id, Department_id),
	FOREIGN KEY (Product_id) REFERENCES Products(ID),
	FOREIGN KEY (Department_id) REFERENCES Departments(ID)
);

Create Table ProductAllergenGroups(
	Product_id INT,
	AllergenGroup_id INT,
	PRIMARY KEY(Product_id, AllergenGroup_id),
	FOREIGN KEY (Product_id) REFERENCES Products(ID),
	FOREIGN KEY (AllergenGroup_id) REFERENCES AllergenGroups(ID)
);

Create Table DepartmentIngredients(
	Department_id INT,
	Ingredient_id INT,
	PRIMARY KEY(Department_id, Ingredient_id),
	FOREIGN KEY (Department_id) REFERENCES Departments(ID),
	FOREIGN KEY (Ingredient_id) REFERENCES Ingredients(ID)
);