package com.talentpath.JobLister.controllers;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.services.ListingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/listings")
public class ListingController {

    @Autowired
    private ListingService listingService;

    @PostMapping
    public ResponseEntity saveListing(@RequestBody Listing listing) {
        ResponseEntity response;
        try {
            response = ResponseEntity.ok(listingService.saveListing(listing));
        } catch(Exception e) {
            // TODO: Create custom exception for handling bad inputs
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping
    public ResponseEntity getAllListings() {
        ResponseEntity response;
        try {
            response = ResponseEntity.ok(listingService.getAllListings());
        } catch (Exception e) {
            // TODO: Create custom exception
            response = ResponseEntity.notFound().build();
        }
        return response;
    }

    @GetMapping("/{listingId}")
    public ResponseEntity getListingById(@PathVariable Integer listingId) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingById(listingId));
        } catch(Exception e) {
            // TODO: Create custom exception for bad inputs and nonexistent listings
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping("/job/{name}")
    public ResponseEntity getListingByJobName(@PathVariable("name") String jobName) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingsByJobName(jobName));
        } catch(Exception e) {
            // TODO: Create custom exception for bad input, no input or nothing found
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping("/{city}/{state}")
    public ResponseEntity getListingByCityAndState(@PathVariable String city,
                                                   @PathVariable String state) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingsByCityAndState(city, state));
        } catch(Exception e) {
            // TODO: Create custom exception for bad input
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping("/employment/{type}")
    public ResponseEntity getListingByEmploymentType(@PathVariable String type) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingsByEmploymentType(type));
        } catch(Exception e) {
            // TODO: Create custom exception for bad input
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping("/industry/{industry}")
    public ResponseEntity getListingsByIndustry(@PathVariable String industry) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingsByIndustry(industry));
        } catch (Exception e) {
            // TODO: Create custom exception for bad input
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping("/company/{company}")
    public ResponseEntity getListingsByCompany(@PathVariable String company) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingsByCompany(company));
        } catch (Exception e) {
            // TODO: Create custom exception for bad input
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @GetMapping("/salary/{low}/{high}")
    public ResponseEntity getListingsBySalaryRange(@PathVariable Integer low,
                                                   @PathVariable Integer high) {
        ResponseEntity response;
        try {
            response = ResponseEntity.of(listingService.getListingsBySalaryRange(low, high));
        } catch (Exception e) {
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }
}