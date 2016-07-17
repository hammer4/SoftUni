<?php $this->title = 'Delete Post'; ?>

<h1>Are you sure you want to delete this post?</h1>

<form method="post">
    <div>Title:</div>
    <input type="text" value="<?=htmlspecialchars($this->post['title'])?>" disabled />
    <div>Content:</div>
    <textarea rows="10" disabled><?=
htmlspecialchars($this->post['content'])?></textarea>
    <div>Date:</div>
    <input type="text" value="<?= $this->post['date']?>" disabled />
    <div>Author ID:</div>
    <input type="text" value="<?=htmlspecialchars($this->post['user_id'])?>" disabled />
    <div><input type="submit" value="Delete" />
        <a href="<?=APP_ROOT?>/posts">[Cancel]</a>
    </div>
</form>
