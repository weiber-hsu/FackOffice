﻿using FakeOffice.Models;

namespace FakeOffice.Repository;

public interface IMemberRepo
{
    void Register(Member member);
}