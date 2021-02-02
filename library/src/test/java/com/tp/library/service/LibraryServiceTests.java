package com.tp.library.service;

import com.tp.library.exceptions.*;
import com.tp.library.model.Book;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.HashSet;
import java.util.NoSuchElementException;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;


@SpringBootTest
public class LibraryServiceTests {

    @Autowired
    LibraryService libraryService;

    Set<String> authors  = new HashSet<>(){{
        add("Terry Pratchett");
        add("Neil Gaiman");
    }};;

    Book book = new Book("Good Omens", authors, 1990);

    @BeforeEach
    public void setup() throws NullFieldException,
            InvalidPublicationYearException, EmptyFieldException, MissingAuthorException, EmptyCollectionException, BookNotFoundException {
        for(Book book : libraryService.getAllBooks()) {
            libraryService.deleteBook(book.getBookId());
        }
        libraryService.saveBook(book);
    }

    @Test
    public void savingBookWithNullTitleShouldThrowException() {
        Book book = new Book(null, authors, 2000);
        assertThrows(NullFieldException.class, () -> libraryService.saveBook(book));
    }

    @Test
    public void savingBookWithNullAuthorsShouldThrowException() {
        Book book = new Book("Book Title", null, 2000);
        assertThrows(NullFieldException.class, () -> libraryService.saveBook(book));
    }

    @Test
    public void savingBookWithNullPublicationYearShouldThrowException() {
        Book book = new Book("Title", this.book.getAuthors(), null);
        assertThrows(NullFieldException.class, () -> libraryService.saveBook(book));
    }

    @Test
    public void gettingAllBooksWithNullTitleShouldThrowException() {
        assertThrows(NullFieldException.class, () -> libraryService.getBooksByTitle(null));
    }

    @Test
    public void gettingAllBooksWithNullAuthorShouldThrowException() {
        assertThrows(NullFieldException.class, () -> libraryService.getBooksByAuthor(null));
    }

    @Test
    public void gettingAllBooksWithNullYearShouldThrowException() {
        assertThrows(NullFieldException.class, () -> libraryService.getBooksByPublicationYear(null));
    }

    @Test
    public void gettingBooksByTitleWithEmptyStringShouldThrow() {
        assertThrows(EmptyFieldException.class, () -> libraryService.getBooksByTitle(""));
    }

    @Test
    public void gettingBooksByAuthorWithEmptyStringShouldThrow() {
        assertThrows(EmptyFieldException.class, () -> libraryService.getBooksByAuthor(""));
    }

    @Test
    public void gettingBooksWithInvalidPublicationYearShouldThrow() {
        assertThrows(InvalidPublicationYearException.class, () -> libraryService.getBooksByPublicationYear(1500));
        assertThrows(InvalidPublicationYearException.class, () -> libraryService.getBooksByPublicationYear(2022));
    }

    @Test
    public void savingBookWithEmptySetOfAuthorsShouldThrow() {
        Book book = new Book("Book Title", new HashSet<>(), 2000);
        assertThrows(EmptyFieldException.class, () -> libraryService.saveBook(book));
    }

    @Test
    public void savingBookWithInvalidPubYearShouldThrow() {
        Book book = new Book("Title", authors, -1000);
        assertThrows(InvalidPublicationYearException.class, () -> libraryService.saveBook(book));
    }

    @Test
    public void savingBookWithAuthorEntryBlankShouldThrow() {
        authors.add("");
        authors.add(null);
        Book book = new Book("Title", this.book.getAuthors(), 2000);
        assertThrows(MissingAuthorException.class, () -> libraryService.saveBook(book));
    }

    @Test
    public void gettingBooksByInvalidBookIdShouldThrow() {
        assertThrows(NoSuchElementException.class, () -> libraryService.getBookById(0));
        assertThrows(NoSuchElementException.class, () -> libraryService.getBookById(-1));
        assertThrows(NoSuchElementException.class, () -> libraryService.getBookById(Integer.MIN_VALUE));
    }
}
