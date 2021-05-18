import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentType } from 'src/app/shared/models/enums/content-type';
import { Page } from 'src/app/shared/models/page/page';
import { PageDetails } from 'src/app/shared/models/page/page-details';

@Component({
    selector: 'app-page',
    templateUrl: './page.component.html',
    styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {

    pages: Page[];
    pageDetails: PageDetails;

    constructor(
        private activatedRoute: ActivatedRoute,
    ) { }

    ngOnInit(): void {
        this.pages = this.activatedRoute.snapshot.data.pages || [];
        this.pageDetails = this.activatedRoute.snapshot.data.pageDetails;
    }

    get ContentType() {
        return ContentType;
    }
}