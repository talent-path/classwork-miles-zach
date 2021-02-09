package com.talentpath.JobLister.controllers;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.services.ListingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ListingController {

    @Autowired
    private ListingService listingService;

    @PostMapping("/listing")
    public ResponseEntity saveListing(@RequestBody Listing listing) {
        return ResponseEntity.ok(listingService.saveListing(listing));
    }
}
