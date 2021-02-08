package com.talentpath.JobLister.models;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.AccessLevel;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
@NoArgsConstructor
@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
@Table(name = "Applications")
public class Application implements Serializable {

    @Id
    @Setter(AccessLevel.PROTECTED)
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "application_id")
    private Integer applicationId;

    @ManyToOne(cascade = CascadeType.ALL, fetch = FetchType.EAGER)
    @JoinColumn(name = "listing_id")
    private Listing listing;

    @Column(name = "applicant_name", nullable = false)
    private String applicantName;

    @Column(name = "phone_number", nullable = false)
}
