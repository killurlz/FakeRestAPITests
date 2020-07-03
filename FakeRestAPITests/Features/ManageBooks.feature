Feature: ManageBooks
	In order to manage the book inventory
	as FakeRestAPI user
	I want to be able to read, add, update, delete books from inventory

Scenario Outline: Add a book with valid data
	When a user requests to add a book using <Id>, <Title>, <Description>, <Page Count>, <Excerpt> and <Publish Date>
	Then an OK response containing the newly added book's information should be returned to the user
Examples: 
| Id | Title        | Description        | Page Count | Excerpt        | Publish Date                      |
| 0  | Test Title 1 | Test Description 1 | 111        | Book Excerpt 1 | 2020-02-23T15:18:52.3294966+00:00 |
| 0  | Test Title 2 | Test Description 2 | 222        | Book Excerpt 2 | 2020-01-23T15:18:52.3294966+00:00 |

Scenario Outline: Update a book with valid data
	When a user requests to update a book using <Id>, <Title>, <Description>, <Page Count>, <Excerpt> and <Publish Date>
	Then an OK response containing the updated book's information should be returned to the user
Examples: 
| Id | Title         | Description         | Page Count | Excerpt      | Publish Date                      |
| 0  | UpdatedTitle6 | UpdatedDescription6 | 666        | BookExcerpt6 | 2020-05-23T15:18:52.3294966+00:00 |
| 0  | UpdatedTitle7 | UpdatedDescription7 | 777        | BookExcerpt7 | 2020-06-23T15:18:52.3294966+00:00 |

Scenario Outline: Delete a book by Id
	When a user requests to delete a certain book using <Id>
	Then an OK response containing an empty body is returned to the user
Examples:
| Id |
| 1  |
| 2  |
| 6  |
| 7  |

Scenario: Read all present books
	When a user requests to read all books
	Then an OK response containing the following books should be returned to the user
	| Id | Title    | Description                                              | Page Count | Excerpt                                                                                                                                                                                                                                                                                  |
	| 0  | Book 1   | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. | 100        | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. |
	| 0  | Book 100 | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. | 10000      | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. |
	| 0  | Book 200 | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. | 20000      | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. |

Scenario: Read a book
	When a user requests to read a book using id:1
	Then an OK response containing the following book's information should be returned to the user
	| Id | Title    | Description                                              | Page Count | Excerpt                                                                                                                                                                                                                                                                                  |
	| 1  | Book 1   | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. | 100        | Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem.Lorem lorem lorem. Lorem lorem lorem. Lorem lorem lorem. |