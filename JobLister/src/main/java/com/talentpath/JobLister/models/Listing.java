package com.talentpath.JobLister.models;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.*;

import javax.persistence.*;
import java.io.Serializable;
import java.time.Instant;
import java.util.Set;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
@Entity
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
@Table(name = "listing")
public class Listing implements Serializable {

    @Id
    @Setter(AccessLevel.PROTECTED)
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "listing_id", unique = true)
    private Integer listingId;

    @Column(name = "listing_name", nullable = false)
    private String listingName;

    @Column(name = "industry", nullable = false)
    private String industry;

    @Column(name = "employment_type", nullable = false)
    private String employmentType;

    @Column(name = "city", nullable = false)
    private String city;

    @Column(name = "state", nullable = false)
    private String state;

    @Column(name = "date_posted", nullable = false, columnDefinition = "timestamptz")
    private Instant datePosted;

    @OneToMany(mappedBy = "listing", cascade = CascadeType.ALL, fetch = FetchType.EAGER)
    private Set<Application> applications;
}
