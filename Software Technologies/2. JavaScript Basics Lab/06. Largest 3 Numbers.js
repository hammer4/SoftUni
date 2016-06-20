function largest3Numbers(arr) {
    let nums = arr.map(Number);
    nums.sort((a, b) => b-a);
    let count = Math.min(3, nums.length);
    for(let i=0; i<count; i++) {
        console.log(nums[i]);
    }
}
