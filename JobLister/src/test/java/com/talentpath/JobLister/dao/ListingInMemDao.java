package com.talentpath.JobLister.dao;

import com.talentpath.JobLister.models.Listing;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
@Profile({"serviceTest"})
public class ListingInMemDao {

    Optional<List<Listing>> findByListingNameContainingIgnoreCase(String name){
        throw new UnsupportedOperationException();
    }

    Optional<List<Listing>> findByCityAndStateAllIgnoreCase(String city, String state){
        throw new UnsupportedOperationException();
    }

    Optional<List<Listing>> findByEmploymentTypeIgnoreCase(String type){
        throw new UnsupportedOperationException();
    }

    Optional<List<Listing>> findByIndustryIgnoreCase(String industry){
        throw new UnsupportedOperationException();
    }

    Optional<List<Listing>> findByCompanyContainingIgnoreCase(String company){
        throw new UnsupportedOperationException();
    }

    Optional<List<Listing>> findBySalaryBetween(Integer low, Integer high){
        throw new UnsupportedOperationException();
    }

}
