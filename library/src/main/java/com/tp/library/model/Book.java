package com.tp.library.model;

import java.util.Set;

public class Book {

    private Integer bookId;
    private String title;
    private Set<String> authors;
    private Integer publicationYear;

    public Book(String title, Set<String> authors, Integer publicationYear) {
        this.title = title;
        this.authors = authors;
        this.publicationYear = publicationYear;
    }

    public Book() {
    }

    public Integer getBookId() {
        return bookId;
    }

    public void setBookId(Integer bookId) {
        this.bookId = bookId;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public Set<String> getAuthors() {
        return authors;
    }

    public void setAuthors(Set<String> authors) {
        this.authors = authors;
    }

    public Integer getPublicationYear() {
        return publicationYear;
    }

    public void setPublicationYear(Integer publicationYear) {
        this.publicationYear = publicationYear;
    }
}
