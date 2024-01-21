let loadMoreBtn = document.querySelector('#load-more-btn');
let boxesList = [...document.querySelectorAll('.travel-listing .travel-detail-card')];
let currentItem = 3;
if (boxesList.length <= currentItem) {
    loadMoreBtn.style.display = "none";
}

loadMoreBtn.onclick = () => {
    for (var i = currentItem; i < currentItem + 3; i++) {
        boxesList[i].style.display = "block";

        currentItem += 3;

        if (currentItem >= boxesList.length) {
            loadMoreBtn.style.display = "none";
        }
    }
}

let loadMoreBtnSuggest = document.querySelector('#load-more-btn-suggest');
let boxesSuggest = [...document.querySelectorAll('.travel-list-suggest .travel-detail-card')];
let currentItemSuggest = 3;
if (boxesSuggest.length <= currentItemSuggest) {
    loadMoreBtnSuggest.style.display = "none";
}

loadMoreBtnSuggest.onclick = () => {
    for (var i = currentItemSuggest; i < currentItemSuggest + 3; i++) {
        boxesSuggest[i].style.display = "block";

        currentItemSuggest += 3;

        if (currentItemSuggest >= boxesSuggest.length) {
            loadMoreBtnSuggest.style.display = "none";
        }
    }
}