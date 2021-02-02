package com.tp.library.persistence;

import com.tp.library.exceptions.*;
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

    Set<String> authors = new HashSet<>();

    Book book = new Book();

    @BeforeEach
    public void setup() throws BookNotFoundException {
        for(String author : authors) {
            authors.remove(author);
        }
        for(Book book : libraryDao.getAllBooks()) {
            libraryDao.deleteBook(book.getBookId());
        }
        book.setTitle("Good Omens");
        book.setAuthors(authors);
        book.setPublicationYear(1990);
        authors.add("Terry Pratchett");
        authors.add("Neil Gaiman");
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
    public void addingNullBookShouldThrowIllegalArgumentException() {
        assertThrows(NullArgumentException.class, () -> libraryDao.saveBook(null));
    }

    @Test
    public void addingBookWithNullTitleShouldThrowNullFieldException() {
        book.setTitle(null);
        assertThrows(NullFieldException.class, () -> libraryDao.saveBook(book));
    }

    @Test
    public void addingBookWithNullAuthorsShouldThrowNullFieldException() {
        book.setAuthors(null);
        assertThrows(NullFieldException.class, () -> libraryDao.saveBook(book));
    }

    @Test
    public void addingBookWithNullYearShouldThrowNullFieldException() {
        book.setPublicationYear(null);
        assertThrows(NullFieldException.class, () -> libraryDao.saveBook(book));
    }

    @Test
    public void addingBookWithOneNullAuthorShouldThrowMissingAuthorException() {
        authors.add(null);
        assertThrows(MissingAuthorException.class, () -> libraryDao.saveBook(book));
    }

    @Test
    public void gettingAllBooksShouldReturnTheEntireCollection() {
        libraryDao.saveBook(book);

        Book newBook = new Book();
        newBook.setTitle("Harry Potter");
        newBook.setAuthors(new HashSet<>(){{ add("J.K. Rowling"); }});
        newBook.setPublicationYear(1997);
        libraryDao.saveBook(newBook);

        List<Book> allBooks = libraryDao.getAllBooks();

        assertEquals(2, allBooks.size());
        assertEquals("Good Omens", allBooks.get(0).getTitle());
        assertEquals("Harry Potter", allBooks.get(1).getTitle());
        assertEquals(1, allBooks.get(0).getBookId());
        assertEquals(2, allBooks.get(1).getBookId());
        assertTrue(allBooks.get(0).getAuthors().contains("Neil Gaiman"));
        assertTrue(allBooks.get(0).getAuthors().contains("Terry Pratchett"));
        assertTrue(allBooks.get(1).getAuthors().contains("J.K. Rowling"));
        assertEquals(1990, allBooks.get(0).getPublicationYear());
        assertEquals(1997, allBooks.get(1).getPublicationYear());
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
        assertEquals(2, harryPotterBooks.get(0).getBookId());
        assertEquals(2000, harryPotterBooks.get(0).getPublicationYear());
        assertEquals(author, harryPotterBooks.get(0).getAuthors());
    }

    @Test
    public void getBooksByNullTitleShouldThrowNullArgument() {
        assertThrows(NullArgumentException.class, () -> libraryDao.getBooksByTitle(null));
    }

    @Test
    public void gettingAllBooksWithAuthorShouldReturnOnlyBooksWithAuthor() {
        libraryDao.saveBook(book);
        List<Book> booksByNeilGaiman = libraryDao.getBooksByAuthor("Neil Gaiman");
        assertEquals(1, booksByNeilGaiman.get(0).getBookId());
        assertTrue(booksByNeilGaiman.get(0).getAuthors().contains("Neil Gaiman"));
        assertEquals("Good Omens", booksByNeilGaiman.get(0).getTitle());
        assertEquals(1990, booksByNeilGaiman.get(0).getPublicationYear());
    }

    @Test
    public void getBooksByNullAuthorThrowsNullArgumentException() {
        assertThrows(NullArgumentException.class, () -> libraryDao.getBooksByAuthor(null));
    }

    @Test
    public void gettingBooksByPublicationYearShouldReturnOnlyBooksPublishedInThatYear() {
        libraryDao.saveBook(book);
        List<Book> booksPublishedIn1990 = libraryDao.getBooksByPublicationYear(1990);
        assertEquals(1, booksPublishedIn1990.size());
        assertEquals(1, booksPublishedIn1990.get(0).getPublicationYear());
        assertEquals("Good Omens", booksPublishedIn1990.get(0).getTitle());
        assertEquals(1990, booksPublishedIn1990.get(0).getPublicationYear());
    }

    @Test
    public void getBooksByNullYearThrowsNullArgumentException() {
        assertThrows(NullArgumentException.class, () -> libraryDao.getBooksByPublicationYear(null));
    }

    @Test
    public void gettingBookByBookIdShouldReturnExpectedBook() throws BookNotFoundException {
        Book savedBook = libraryDao.saveBook(book);
        Book book = libraryDao.getBookById(savedBook.getBookId());
        assertEquals(savedBook.getBookId(), book.getBookId());
        assertEquals("Good Omens", book.getTitle());
        assertEquals(this.book.getAuthors(), book.getAuthors());
        assertEquals(1990, book.getPublicationYear());
    }

    @Test
    public void getBooksByNullIdShouldThrowNullArgumentException() {
        assertThrows(IllegalArgumentException.class, () -> libraryDao.getBookById(null));
    }

    @Test
    public void deletingBookShouldRemoveBookFromList() throws BookNotFoundException {
        Book savedBook = libraryDao.saveBook(book);
        libraryDao.deleteBook(savedBook.getBookId());
        int size = libraryDao.getAllBooks().size();
        assertEquals(0, size);
    }

    @Test
    public void updatingBookShouldOverwriteExistingAttributes() throws BookNotFoundException {
        Book savedBook = libraryDao.saveBook(book);
        Book newBook = new Book("Bad Omens", new HashSet<>(){{ add("Zack Miles");}}, 2021);
        libraryDao.updateBook(savedBook.getBookId(), newBook);
        Book updatedBook = libraryDao.getBookById(savedBook.getBookId());
        assertEquals("Bad Omens", updatedBook.getTitle());
        assertEquals(2021, updatedBook.getPublicationYear());
        assertTrue(updatedBook.getAuthors().contains("Zack Miles"));
    }

    @Test
    public void updateNullBookThrowsNullArgumentException() {
        assertThrows(NullArgumentException.class, () -> libraryDao.updateBook(1, null));
    }

    @Test
    public void updateBookWithNullIdThrowsNullArgumentException() {
        assertThrows(NullArgumentException.class, () -> libraryDao.updateBook(null, book));
    }

    @Test
    public void updateBookWithInvalidIdThrowsInvalidBookIdException() {
        assertThrows(InvalidBookIdException.class, () -> libraryDao.updateBook(100, book));
    }

    @Test
    public void updateBookWithNullTitleThrowsException() {
        libraryDao.saveBook(book);
        book.setTitle(null);
        assertThrows(NullFieldException.class, () -> libraryDao.updateBook(1, book));
    }

    @Test
    public void updateBookWithNullAuthorCollectionThrowsException() {
        Book savedBook = libraryDao.saveBook(book);
        book.setAuthors(null);
        assertThrows(NullFieldException.class, () -> libraryDao.updateBook(savedBook.getBookId(), book));
    }

}
