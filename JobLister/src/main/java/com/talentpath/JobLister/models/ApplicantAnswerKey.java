package com.talentpath.JobLister.models;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;
import java.util.Objects;

@Embeddable
public class ApplicantAnswerKey implements Serializable {

    @Column(name = "question_id")
    Integer questionId;

    @Column(name = "applicant_id")
    Integer applicantId;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        ApplicantAnswerKey that = (ApplicantAnswerKey) o;
        return questionId.equals(that.questionId) && applicantId.equals(that.applicantId);
    }

    @Override
    public int hashCode() {
        return Objects.hash(questionId, applicantId);
    }
}
