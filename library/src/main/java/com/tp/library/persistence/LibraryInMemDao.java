package com.tp.library.persistence;

import com.tp.library.model.Book;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.stream.Collectors;

@Repository
public class LibraryInMemDao implements LibraryDao {

    private List<Book> allBooks = new ArrayList<>();

    @Override
    public List<Book> getAllBooks() {
        List<Book> books = new ArrayList<>(allBooks);
        return books;
    }

    @Override
    public List<Book> getBooksByTitle(String title) {
        return allBooks.stream()
                .filter(book -> book.getTitle().equalsIgnoreCase(title))
                .collect(Collectors.toList());
    }

    @Override
    public List<Book> getBooksByAuthor(String author) {
        return allBooks.stream()
                .filter(book -> book.getAuthors()
                        .stream()
                        .anyMatch(a -> a.equalsIgnoreCase(author)))
                .collect(Collectors.toList());
    }

    @Override
    public List<Book> getBooksByPublicationYear(Integer year) {
        return allBooks.stream()
                .filter(book -> book.getPublicationYear().equals(year))
                .collect(Collectors.toList());
    }

    @Override
    public Book getBookById(Integer id) {
        return allBooks.stream()
                .filter(book -> book.getBookId().equals(id))
                .findFirst().orElseThrow(NoSuchElementException::new);
    }

    @Override
    public void deleteBook(Integer id) {
        Book bookToDelete = getBookById(id);
        allBooks.remove(bookToDelete);
    }

    @Override
    public void updateBook(Integer id, Book book) {
        Book bookToUpdate = getBookById(id);
        bookToUpdate.setTitle(book.getTitle());
        bookToUpdate.setAuthors(book.getAuthors());
        bookToUpdate.setPublicationYear(book.getPublicationYear());
    }

    @Override
    public Book saveBook(Book book) {
        book.setBookId(0);
        int id = book.getBookId();

        for(Book b : allBooks) {
            if(b.getBookId() > id) {
                id = b.getBookId();
            }

        }

        id++;

        book.setBookId(id);
        allBooks.add(book);
        return book;
    }
}
