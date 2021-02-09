package com.talentpath.JobLister.services;

import com.talentpath.JobLister.models.Listing;
import com.talentpath.JobLister.persistence.ListingDao;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class ListingService {

    @Autowired
    private ListingDao listingDao;

    public Listing saveListing(Listing listing) {
        return listingDao.save(listing);
    }

    public Optional<Listing> getListingById(Integer listingId) {
        return listingDao.findById(listingId);
    }

    public List<Listing> getAllListings() {
        return listingDao.findAll();
    }

    public Optional<List<Listing>> getListingsByJobName(String jobName) {
        return listingDao.findByListingNameContainingIgnoreCase(jobName);
    }

    public Optional<List<Listing>> getListingsByCityAndState(String city, String state) {
        return listingDao.findByCityAndStateAllIgnoreCase(city, state);
    }

    public Optional<List<Listing>> getListingsByEmploymentType(String type) {
        return listingDao.findByEmploymentTypeIgnoreCase(type);
    }

    public Optional<List<Listing>> getListingsByIndustry(String industry) {
        return listingDao.findByIndustryIgnoreCase(industry);
    }

    public Optional<List<Listing>> getListingsByCompany(String company) {
        return listingDao.findByCompanyContainingIgnoreCase(company);
    }

    public Optional<List<Listing>> getListingsBySalaryRange(Integer low, Integer high) {
        return listingDao.findBySalaryBetween(low, high);
    }
}
