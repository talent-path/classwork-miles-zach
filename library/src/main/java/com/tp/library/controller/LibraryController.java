package com.tp.library.controller;

import com.tp.library.model.Book;
import com.tp.library.service.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;

@Controller
public class LibraryController {

    @Autowired
    LibraryService libraryService;

    @GetMapping("/books")
    public List<Book> getAllBooks() {
        throw new UnsupportedOperationException();
    }

    @GetMapping("/books/{id}")
    public Book getBookById(@PathVariable Integer id) {
        throw new UnsupportedOperationException();
    }

    @GetMapping("/books/{title}")
    public List<Book> getBooksByTitle(@PathVariable String title) {
        throw new UnsupportedOperationException();
    }

    @GetMapping("/books/{author}")
    public List<Book> getBooksByAuthor(@PathVariable String author) {
        throw new UnsupportedOperationException();
    }

    @GetMapping("/books/{publicationYear}")
    public List<Book> getBooksByPublicationYear(@PathVariable Integer publicationYear) {
        throw new UnsupportedOperationException();
    }

    @PostMapping("/books")
    public Book addBook(@RequestBody Book book) {
        throw new UnsupportedOperationException();
    }
}
