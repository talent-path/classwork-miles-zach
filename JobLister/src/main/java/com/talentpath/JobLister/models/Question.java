package com.talentpath.JobLister.models;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.*;

import javax.persistence.*;
import java.io.Serializable;
import java.util.HashSet;
import java.util.Set;

@AllArgsConstructor
@NoArgsConstructor
@Getter
@Setter
@Entity
@JsonIgnoreProperties(value = {"hibernateLazyInitializer", "handler", "listing"}, allowSetters = true)
@Table
public class Question implements Serializable {

    @Id
    @Setter(AccessLevel.PROTECTED)
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "question_id", unique = true)
    private Integer questionId;

    @ManyToOne(cascade = CascadeType.ALL, fetch = FetchType.EAGER)
    @JoinColumn(name = "listing_id")
    private Listing listing;

    @Column(nullable = false)
    private String question;

    @Column
    private Boolean required;

    @OneToMany(mappedBy = "question")
    private Set<Answer> answers = new HashSet<>();

}
