package com.talentpath.JobLister.dao;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.persistence.ListingDao;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.ActiveProfiles;

import java.time.Instant;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
@ActiveProfiles("daoTesting")
public class ListingDaoTests {

    @Autowired
    ListingDao listingDao;

    @BeforeEach
    void setup() {
        listingDao.deleteAll();
    }

    @Test
    void createListing() {
        Listing listing = new Listing();
        listing.setListingName("Marine Biologist");
        listing.setIndustry("Environmental Science");
        listing.setCompany("Diver's Anonymous");
        listing.setCity("Ft. Myers");
        listing.setState("Florida");
        listing.setCountry("United States");
        listing.setEmploymentType("Contract");
        listing.setSalary(40000);
        listing.setCurrency("USD");
        listing.setDatePosted(Instant.now());

        Listing savedListing = listingDao.save(listing);

        assertNotNull(savedListing.getListingId());
        assertEquals("Marine Biologist", savedListing.getListingName());
        assertEquals("Diver's Anonymous", savedListing.getCompany());
        assertEquals(40000, savedListing.getSalary());
        assertEquals("USD", savedListing.getCurrency());
        assertEquals("Environmental Science", savedListing.getIndustry());
        assertEquals("Contract", savedListing.getEmploymentType());
        assertEquals("Ft. Myers", savedListing.getCity());
        assertEquals("Florida", savedListing.getState());
        assertEquals("United States", savedListing.getCountry());
        assertEquals(listing.getDatePosted(), savedListing.getDatePosted());
    }
}
