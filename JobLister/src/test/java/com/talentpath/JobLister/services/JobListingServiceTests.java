package com.talentpath.JobLister.services;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.persistence.ListingDao;
import com.talentpath.JobLister.persistence.QuestionDao;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.dao.DataIntegrityViolationException;

import java.time.Instant;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Optional;

import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;

@ExtendWith(MockitoExtension.class)
public class JobListingServiceTests {

    @InjectMocks
    JobListingService service;

    @Mock
    ListingDao listingDao;

    @Mock
    QuestionDao questionDao;

    @Test
    public void createListing() {
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

        service.saveListing(listing);

        verify(listingDao, times(1)).save(listing);
    }

    @Test
    public void creatingListingWithNullRequiredFieldsShouldThrowNullFieldException() {
        Listing listing = new Listing();
        listing.setListingName("Marine Biologist");
        listing.setIndustry("Environmental Science");
        listing.setCompany("Diver's Anonymous");
        listing.setCity("Ft. Myers");
        listing.setState("Florida");
        listing.setCountry("United States");
        listing.setEmploymentType(null);
        listing.setSalary(40000);
        listing.setCurrency("USD");

        when(listingDao.save(listing)).thenThrow(DataIntegrityViolationException.class);

        assertThrows(DataIntegrityViolationException.class, () -> service.saveListing(listing));
    }

    @Test
    public void getAllListings() {
        List<Listing> listings = new ArrayList<>();
        Listing listing = new Listing();
        listing.setListingName("Marine Biologist");
        listing.setIndustry("Environmental Science");
        listing.setCompany("Diver's Anonymous");
        listing.setCity("Ft. Myers");
        listing.setState("Florida");
        listing.setEmploymentType("Contract");
        listing.setSalary(40000);

        listings.add(listing);
        listings.add(listing);
        listings.add(listing);

        when(listingDao.findAll()).thenReturn(listings);

        List<Listing> allListings = service.getAllListings();

        assertEquals(3, allListings.size());
        verify(listingDao, times(1)).findAll();
    }

    @Test
    public void getListingById() {
        Listing listing = new Listing(1, "Park Ranger", "Blue Ridge Park Patrol",
                45000, "USD", "Wildlife Preservation", "Full-Time", "Helen", "Georgia", "US", Instant.now(), new HashSet<>(), new HashSet<>());
        when(listingDao.findById(1)).thenReturn(Optional.of(listing));
        Optional<Listing> listingWithId1 = service.getListingById(1);
        assertEquals(listing, listingWithId1.get());
        verify(listingDao, times(1)).findById(1);
    }


}
