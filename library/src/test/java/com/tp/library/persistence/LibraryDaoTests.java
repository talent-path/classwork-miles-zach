package com.tp.library.persistence;

import com.tp.library.model.Book;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
public class LibraryDaoTests {

    @Autowired
    LibraryDao libraryDao;

    Set<String> authors = authors = new HashSet<>(){{
        add("Terry Pratchett");
        add("Neil Gaiman");
    }};;

    Book book = new Book("Good Omens", authors, 1990);

    @BeforeEach
    public void setup() {
        for(Book book : libraryDao.getAllBooks()) {
            libraryDao.deleteBook(book.getBookId());
        }
    }

    @Test
    public void savingBookShouldReturnSameBookWithUniqueId() {
        Book savedBook = libraryDao.saveBook(book);

        assertNotNull(savedBook.getBookId());
        assertEquals("Good Omens", savedBook.getTitle());
        assertEquals(authors, savedBook.getAuthors());
        assertEquals(1990, savedBook.getPublicationYear());
    }

    @Test
    public void gettingAllBooksShouldReturnTheEntireCollection() {
        libraryDao.saveBook(book);
        libraryDao.saveBook(book);

        List<Book> allBooks = libraryDao.getAllBooks();

        assertEquals(2, allBooks.size());
    }

    @Test
    public void gettingAllBooksWithGivenTitleShouldReturnOnlyTheBooksWithExactTitle() {
        Set<String> author = new HashSet<>(){{ add("J.K. Rowling"); }};
        Book harryPotter = new Book("Harry Potter",
                author, 2000);

        libraryDao.saveBook(book);
        libraryDao.saveBook(harryPotter);
        List<Book> harryPotterBooks = libraryDao.getBooksByTitle("Harry Potter");

        assertEquals("Harry Potter", harryPotterBooks.get(0).getTitle());
    }

    @Test
    public void gettingAllBooksWithAuthorShouldReturnOnlyBooksWithAuthor() {
        libraryDao.saveBook(book);
        List<Book> booksByNeilGaiman = libraryDao.getBooksByAuthor("Neil Gaiman");
        assertTrue(booksByNeilGaiman.get(0).getAuthors().contains("Neil Gaiman"));
    }

    @Test
    public void gettingBooksByPublicationYearShouldReturnOnlyBooksPublishedInThatYear() {
        libraryDao.saveBook(book);
        List<Book> booksPublishedIn1990 = libraryDao.getBooksByPublicationYear(1990);
        assertEquals(1990, booksPublishedIn1990.get(0).getPublicationYear());
    }

    @Test
    public void gettingBookByBookIdShouldReturnExpectedBook() {
        Book savedBook = libraryDao.saveBook(book);
        Book book = libraryDao.getBookById(savedBook.getBookId());
        assertEquals(savedBook.getBookId(), book.getBookId());
        assertEquals("Good Omens", book.getTitle());
        assertEquals(this.book.getAuthors(), book.getAuthors());
        assertEquals(1990, book.getPublicationYear());
    }

    @Test
    public void deletingBookShouldRemoveBookFromList() {
        Book savedBook = libraryDao.saveBook(book);
        libraryDao.deleteBook(savedBook.getBookId());
        int size = libraryDao.getAllBooks().size();
        assertEquals(0, size);
    }

    @Test
    public void updatingBookShouldOverwriteExistingAttributes() {
        Book savedBook = libraryDao.saveBook(book);
        Book book = libraryDao.getBookById(savedBook.getBookId());
        Book newBook = new Book(savedBook.getBookId(), "Bad Omens", book.getAuthors(), 2021);
        libraryDao.updateBook(savedBook.getBookId(), newBook);
        Book updatedBook = libraryDao.getBookById(savedBook.getBookId());
        assertEquals("Bad Omens", updatedBook.getTitle());
        assertEquals(2021, updatedBook.getPublicationYear());
    }

}
