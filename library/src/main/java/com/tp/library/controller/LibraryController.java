package com.tp.library.controller;

import com.tp.library.exceptions.*;
import com.tp.library.model.Book;
import com.tp.library.service.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@Controller
public class LibraryController {

    @Autowired
    LibraryService libraryService;

    @GetMapping("/books")
    public ResponseEntity<List<Book>> getAllBooks() {
        ResponseEntity<List<Book>> entity;
        try {
            entity = ResponseEntity.ok(libraryService.getAllBooks());
        } catch(Exception e) {
            entity = ResponseEntity.badRequest().build();
        }
        return entity;
    }

    @GetMapping("/books/id/{id}")
    public ResponseEntity<Book> getBookById(@PathVariable Integer id) {
        ResponseEntity<Book> entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBookById(id));
        } catch( NoSuchElementException e) {
            entity = ResponseEntity.badRequest().build();
        }
        return entity;
    }

    @GetMapping("/books/title/{title}")
    public ResponseEntity<List<Book>> getBooksByTitle(@PathVariable String title) {
        ResponseEntity<List<Book>> entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBooksByTitle(title));
        } catch(EmptyFieldException e) {
            entity = ResponseEntity.badRequest().build();
        }
        return entity;
    }

    @GetMapping("/books/author/{author}")
    public ResponseEntity<List<Book>> getBooksByAuthor(@PathVariable String author) {
        ResponseEntity<List<Book>> entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBooksByAuthor(author));
        } catch(EmptyFieldException e) {
            entity = ResponseEntity.badRequest().build();
        }
        return entity;
    }

    @GetMapping("/books/year/{publicationYear}")
    public ResponseEntity<List<Book>> getBooksByPublicationYear(@PathVariable Integer publicationYear) {
        ResponseEntity<List<Book>> entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBooksByPublicationYear(publicationYear));
        } catch(InvalidPublicationYearException e) {
            entity = ResponseEntity.badRequest().build();
        } catch(NoSuchElementException ex) {
            entity = ResponseEntity.notFound().build();
        }
       return entity;
    }

    @PostMapping("/books")
    public ResponseEntity<Book> addBook(@RequestBody Book book) {
        ResponseEntity<Book> entity;
        try {
            entity = ResponseEntity.ok(libraryService.saveBook(book));
        } catch(NullFieldException | EmptyFieldException | InvalidPublicationYearException | MissingAuthorException e) {
            entity = ResponseEntity.badRequest().build();
        }
        return entity;
    }

    @PutMapping("/books/update/{id}")
    public ResponseEntity updateBook(@PathVariable Integer id, @RequestBody Book book) {
        ResponseEntity response;
        try {
            libraryService.updateBook(id, book);
            response = ResponseEntity.accepted().build();
        } catch(NoSuchElementException | NullFieldException | InvalidPublicationYearException | MissingAuthorException | EmptyFieldException e) {
            System.out.println(e.getMessage());
            response = ResponseEntity.badRequest().build();
        }
        return response;
    }

    @DeleteMapping("/books/delete/{id}")
    public ResponseEntity deleteBook(@PathVariable Integer id) {
        ResponseEntity response;
        try {
            libraryService.deleteBook(id);
            response = ResponseEntity.accepted().build();
        } catch(NoSuchElementException e) {
            System.out.println(e.getMessage());
            response = ResponseEntity.notFound().build();
        }
        return response;
    }
}
