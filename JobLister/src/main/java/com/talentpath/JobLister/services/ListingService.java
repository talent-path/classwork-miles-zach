package com.talentpath.JobLister.services;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.persistence.ListingDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ListingService {

    @Autowired
    private ListingDao listingDao;

    public Listing saveListing(Listing listing) {
        return listingDao.save(listing);
    }
}
